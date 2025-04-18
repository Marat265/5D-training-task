// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/product.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace ProductService {
  public static partial class ProductServicee
  {
    static readonly string __ServiceName = "ProductServicee";

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
    static readonly grpc::Marshaller<global::ProductService.ProductRequest> __Marshaller_ProductRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductService.ProductRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProductService.ProductResponse> __Marshaller_ProductResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductService.ProductResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProductService.AddProductRequest> __Marshaller_AddProductRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductService.AddProductRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProductService.UpdateStockRequest> __Marshaller_UpdateStockRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductService.UpdateStockRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::ProductService.StockResponse> __Marshaller_StockResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::ProductService.StockResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ProductService.ProductRequest, global::ProductService.ProductResponse> __Method_GetProduct = new grpc::Method<global::ProductService.ProductRequest, global::ProductService.ProductResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetProduct",
        __Marshaller_ProductRequest,
        __Marshaller_ProductResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ProductService.AddProductRequest, global::ProductService.ProductResponse> __Method_AddProduct = new grpc::Method<global::ProductService.AddProductRequest, global::ProductService.ProductResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddProduct",
        __Marshaller_AddProductRequest,
        __Marshaller_ProductResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::ProductService.UpdateStockRequest, global::ProductService.StockResponse> __Method_UpdateStock = new grpc::Method<global::ProductService.UpdateStockRequest, global::ProductService.StockResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateStock",
        __Marshaller_UpdateStockRequest,
        __Marshaller_StockResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::ProductService.ProductReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ProductServicee</summary>
    [grpc::BindServiceMethod(typeof(ProductServicee), "BindService")]
    public abstract partial class ProductServiceeBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ProductService.ProductResponse> GetProduct(global::ProductService.ProductRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ProductService.ProductResponse> AddProduct(global::ProductService.AddProductRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::ProductService.StockResponse> UpdateStock(global::ProductService.UpdateStockRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ProductServiceeBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetProduct, serviceImpl.GetProduct)
          .AddMethod(__Method_AddProduct, serviceImpl.AddProduct)
          .AddMethod(__Method_UpdateStock, serviceImpl.UpdateStock).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ProductServiceeBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ProductService.ProductRequest, global::ProductService.ProductResponse>(serviceImpl.GetProduct));
      serviceBinder.AddMethod(__Method_AddProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ProductService.AddProductRequest, global::ProductService.ProductResponse>(serviceImpl.AddProduct));
      serviceBinder.AddMethod(__Method_UpdateStock, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::ProductService.UpdateStockRequest, global::ProductService.StockResponse>(serviceImpl.UpdateStock));
    }

  }
}
#endregion
