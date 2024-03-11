using Grpc.Core;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using trainingcommandside;
using trainingcommandside.Extensions;

namespace trainingcommandside.Services
{
    public class InvitationsService(IMediator mediator, ILogger<InvitationsService> logger) : Invitations.InvitationsBase
    {
        private readonly IMediator _mediator = mediator;
       // private readonly AsyncPolicy _policy = ConfigureRetries(logger);

        public override async Task<Response> SendInvitaion(SendInvitaionRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            var id = await/* _policy.ExecuteAsync(() => */_mediator.Send(command);

            return new Response()
            {
              //  Id = id.ToString()
            };
        }

        //private static AsyncPolicy ConfigureRetries(ILogger logger) =>
        //    Policy.Handle<DbUpdateException>()
        //        .WaitAndRetryAsync(new[]
        //        {
        //            TimeSpan.FromSeconds(1),
        //            TimeSpan.FromSeconds(2),
        //            TimeSpan.FromSeconds(3),
        //        }, onRetry: (exception, _, attempt, _) => logger.LogWarning(exception, "Call failed, Retry attempt: {RetryAttempt}", attempt));
    }
}
