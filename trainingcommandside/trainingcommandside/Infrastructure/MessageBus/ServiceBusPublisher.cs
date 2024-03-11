﻿using Azure.Messaging.ServiceBus;
using System.Text.Json;
using System.Text;
using trainingcommandside.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace trainingcommandside.Infrastructure.MessageBus
{
    public class ServiceBusPublisher
    {
        private readonly ServiceBusSender _sender;
        private readonly IServiceProvider _provider;
        private readonly object _lockObject = new();

        public ServiceBusPublisher(ServiceBusClient client, IServiceProvider provider)
        {
            _sender = client.CreateSender("my-topic-name");
            _provider = provider;
        }

        private bool IsBusy { get; set; }

        public void StartPublishing()
        {
            Task.Run(() =>
            {
                try
                {
                    if (IsBusy) return;

                    IsBusy = true;
                    lock (_lockObject)
                    {
                        PublishEvents().GetAwaiter().GetResult();
                    }
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }

        private async Task PublishEvents()
        {
            while (true)
            {
                using var scope = _provider.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                var messages = await dbContext.OutboxMessages
                    .Include(x => x.Event)
                    .OrderBy(x => x.Id)
                    .Take(100)
                    .ToListAsync();

                if (messages.Count == 0) return;

                foreach (var message in messages)
                {
                    if (message.Event is null)
                    {
                        throw new InvalidOperationException("Event is null, please include the event in the query");
                    }

                    var json = JsonSerializer.Serialize(message.Event);

                    var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(json))
                    {
                        PartitionKey = message.Event.AggregateId.ToString(),
                        SessionId = message.Event.AggregateId.ToString(),
                        Subject = message.Event.Type
                    };

                    await _sender.SendMessageAsync(serviceBusMessage);

                    dbContext.OutboxMessages.Remove(message);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
    }

}
