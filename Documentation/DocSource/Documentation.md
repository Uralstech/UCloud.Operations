# Documentation

Please note that the code provided in this page is *purely* for learning purposes and is far from perfect. Remember to null-check all responses!

## Setup

Add an instance of [OperationsManager](~/api/Uralstech.UCloud.Operations.OperationsManager.yml) to your scene. You will need [*OAuth access tokens*](https://developers.google.com/identity/protocols/oauth2)
to authenticate with the operations API. The OAuth permissions required depend on the services you will be using.

## OperationsManager

There's only one method in `OperationsManager`, with a few variants. The `Request` method is used to send requests to the operations API. The
following examples will be using the [*Gemini API*](https://ai.google.dev/) to demonstrate the capabilities of this package.

### Operations.List

> Lists service operations that match the specified filter in the request.
> 
> *Filters are not guaranteed to work.*

```csharp
using Uralstech.UCloud.Operations;

private async void RunOperationsListRequest(string oauthAccessToken)
{
    Debug.Log("Listing all operations.");

    OperationsListResponse response = await OperationsManager.Instance.Request<OperationsListResponse>(oauthAccessToken,
        new OperationsListRequest() // From my testing, filters don't work for this service.
        {
            // This should be replaced with the base URI to the service you are using.
            // For example, if your service's operations endpoint is: abc.com/v1/operations,
            // the URI will be abc.com/v1. If it is abc.com/v1/resource/cba/operations, the
            // URI will be abc.com/v1/resource/cba.
            BaseServiceUri = "https://generativelanguage.googleapis.com/v1",
        });

    Debug.Log($"All operations: {JsonConvert.SerializeObject(response)}");
}
```

Since operations on different services have different result types, there are two versions of `OperationsListResponse`.
A non-generic version, which is being used above, [`OperationsListResponse`](~/api/Uralstech.UCloud.Operations.OperationsListResponse.yml),
and a generic version, in the [`Generic`](~/api/Uralstech.UCloud.Operations.Generic.yml) namespace,
[`OperationsListResponse<TOperation>`](~/api/Uralstech.UCloud.Operations.Generic.OperationsListResponse-1.yml), which can be overridden
with any type that inherits from [`Operation<TMetadata, TResponse>`](~/api/Uralstech.UCloud.Operations.Generic.Operation-2.yml).

The non-generic version overrides `OperationsListResponse<TOperation>` with [`Operation`](~/api/Uralstech.UCloud.Operations.Operation.yml),
which uses the [`ProtobufObject`](~/api/Uralstech.UCloud.ProtobufObject.yml) type as the data.
An example of `Operation<TMetadata, TResponse>` being overridden is [`GeminiTunedModelCreateResponse`](https://github.com/Uralstech/UGemini/blob/c8f90c6757eb628db71941e0ff951bbf57c87123/UGemini/Packages/com.uralstech.ugemini/Runtime/Scripts/Data/Models/Tuning/Create/GeminiTunedModelCreateResponse.cs)
Where `TMetadata` is [`GeminiTunedModelCreationOperationMetadata`](https://github.com/Uralstech/UGemini/blob/c8f90c6757eb628db71941e0ff951bbf57c87123/UGemini/Packages/com.uralstech.ugemini/Runtime/Scripts/Data/Models/Tuning/Create/GeminiTunedModelCreationOperationMetadata.cs) and `TResponse` is [`GeminiTunedModel`](https://github.com/Uralstech/UGemini/blob/c8f90c6757eb628db71941e0ff951bbf57c87123/UGemini/Packages/com.uralstech.ugemini/Runtime/Scripts/Data/Models/Tuning/GeminiTunedModel.cs).

See [`OperationsListRequest`](~/api/Uralstech.UCloud.Operations.OperationsListRequest.yml) for more details.

### Operations.Get

> Gets the latest state of a long-running operation.

```csharp
using Uralstech.UCloud.Operations;

private async void RunOperationGetRequest(string oauthAccessToken, string operationResourceName)
{
    Debug.Log("Getting operation.");

    Operation response = await OperationsManager.Instance.Request<Operation>(oauthAccessToken,
        new OperationGetRequest(operationResourceName)
        {
            BaseServiceUri = "https://generativelanguage.googleapis.com/v1",
        });

    Debug.Log($"Got operation: {JsonConvert.SerializeObject(response)}");
}
```

You can use [`Operation<TMetadata, TResponse>`](~/api/Uralstech.UCloud.Operations.Generic.Operation-2.yml) instead of [`Operation`](~/api/Uralstech.UCloud.Operations.Operation.yml), just like for `OperationsListRequest`.

See [`OperationGetRequest`](~/api/Uralstech.UCloud.Operations.OperationGetRequest.yml) for more details.

### Operations.Cancel

> Cancels an ongoing long-running operation.
> 
> This is not supported for all services.

```csharp
using Uralstech.UCloud.Operations;

private async void RunOperationCancelRequest(string oauthAccessToken, string operationResourceName)
{
    Debug.Log("Cancelling operation.");

    await OperationsManager.Instance.Request(oauthAccessToken,
        new OperationCancelRequest(operationResourceName)
        {
            BaseServiceUri = "https://generativelanguage.googleapis.com/v1",
        });

    Debug.Log("Operation cancelled.");
}
```

See [`OperationCancelRequest`](~/api/Uralstech.UCloud.Operations.OperationCancelRequest.yml) for more details.

### Operations.Delete

> Deletes an ongoing long-running operation. This may or may not actually stop the operation process.
> 
> This is not supported for all services.

```csharp
using Uralstech.UCloud.Operations;

private async void RunOperationDeleteRequest(string oauthAccessToken, string operationResourceName)
{
    Debug.Log("Deleting operation.");

    await OperationsManager.Instance.Request(oauthAccessToken,
        new OperationDeleteRequest(operationResourceName)
        {
            // generativelanguage.googleapis.com does not support this operation!
            BaseServiceUri = "https://abcdefg.someuri.com/v90",
        });

    Debug.Log("Operation deleted.");
}
```

See [`OperationDeleteRequest`](~/api/Uralstech.UCloud.Operations.OperationDeleteRequest.yml) for more details.