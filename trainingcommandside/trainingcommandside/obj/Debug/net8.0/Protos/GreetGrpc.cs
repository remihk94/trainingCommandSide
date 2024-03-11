// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/greet.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace trainingcommandside {
  public static partial class Invitations
  {
    static readonly string __ServiceName = "invitations.commands.v1.Invitations";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::trainingcommandside.SendInvitaionRequest> __Marshaller_invitations_commands_v1_SendInvitaionRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::trainingcommandside.SendInvitaionRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::trainingcommandside.Response> __Marshaller_invitations_commands_v1_Response = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::trainingcommandside.Response.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::trainingcommandside.CancelInvitaionRequest> __Marshaller_invitations_commands_v1_CancelInvitaionRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::trainingcommandside.CancelInvitaionRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::trainingcommandside.AcceptInvitaionRequest> __Marshaller_invitations_commands_v1_AcceptInvitaionRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::trainingcommandside.AcceptInvitaionRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::trainingcommandside.RejectInvitaionRequest> __Marshaller_invitations_commands_v1_RejectInvitaionRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::trainingcommandside.RejectInvitaionRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::trainingcommandside.SendInvitaionRequest, global::trainingcommandside.Response> __Method_SendInvitaion = new grpc::Method<global::trainingcommandside.SendInvitaionRequest, global::trainingcommandside.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendInvitaion",
        __Marshaller_invitations_commands_v1_SendInvitaionRequest,
        __Marshaller_invitations_commands_v1_Response);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::trainingcommandside.CancelInvitaionRequest, global::trainingcommandside.Response> __Method_CancelInvitaion = new grpc::Method<global::trainingcommandside.CancelInvitaionRequest, global::trainingcommandside.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CancelInvitaion",
        __Marshaller_invitations_commands_v1_CancelInvitaionRequest,
        __Marshaller_invitations_commands_v1_Response);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::trainingcommandside.AcceptInvitaionRequest, global::trainingcommandside.Response> __Method_AcceptInvitaion = new grpc::Method<global::trainingcommandside.AcceptInvitaionRequest, global::trainingcommandside.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AcceptInvitaion",
        __Marshaller_invitations_commands_v1_AcceptInvitaionRequest,
        __Marshaller_invitations_commands_v1_Response);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::trainingcommandside.RejectInvitaionRequest, global::trainingcommandside.Response> __Method_RejectInvitaion = new grpc::Method<global::trainingcommandside.RejectInvitaionRequest, global::trainingcommandside.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RejectInvitaion",
        __Marshaller_invitations_commands_v1_RejectInvitaionRequest,
        __Marshaller_invitations_commands_v1_Response);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::trainingcommandside.GreetReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Invitations</summary>
    [grpc::BindServiceMethod(typeof(Invitations), "BindService")]
    public abstract partial class InvitationsBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::trainingcommandside.Response> SendInvitaion(global::trainingcommandside.SendInvitaionRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::trainingcommandside.Response> CancelInvitaion(global::trainingcommandside.CancelInvitaionRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::trainingcommandside.Response> AcceptInvitaion(global::trainingcommandside.AcceptInvitaionRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::trainingcommandside.Response> RejectInvitaion(global::trainingcommandside.RejectInvitaionRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(InvitationsBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendInvitaion, serviceImpl.SendInvitaion)
          .AddMethod(__Method_CancelInvitaion, serviceImpl.CancelInvitaion)
          .AddMethod(__Method_AcceptInvitaion, serviceImpl.AcceptInvitaion)
          .AddMethod(__Method_RejectInvitaion, serviceImpl.RejectInvitaion).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, InvitationsBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SendInvitaion, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::trainingcommandside.SendInvitaionRequest, global::trainingcommandside.Response>(serviceImpl.SendInvitaion));
      serviceBinder.AddMethod(__Method_CancelInvitaion, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::trainingcommandside.CancelInvitaionRequest, global::trainingcommandside.Response>(serviceImpl.CancelInvitaion));
      serviceBinder.AddMethod(__Method_AcceptInvitaion, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::trainingcommandside.AcceptInvitaionRequest, global::trainingcommandside.Response>(serviceImpl.AcceptInvitaion));
      serviceBinder.AddMethod(__Method_RejectInvitaion, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::trainingcommandside.RejectInvitaionRequest, global::trainingcommandside.Response>(serviceImpl.RejectInvitaion));
    }

  }
}
#endregion
