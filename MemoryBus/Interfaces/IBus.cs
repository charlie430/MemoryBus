﻿namespace MemoryBus
{
    using System;
    using System.Threading.Tasks;

    public interface IBus
    {
        void Publish<TRequest>(TRequest request);
        Task PublishAsync<TRequest>(TRequest request);

        IDisposable Subscribe<TRequest>(Action<TRequest> handler);
        IDisposable Subscribe<TRequest>(Action<TRequest> handler, Func<TRequest, bool> filter);
        IDisposable SubscribeAsync<TRequest>(Func<TRequest, Task> handler);
        IDisposable SubscribeAsync<TRequest>(Func<TRequest, Task> handler, Func<TRequest, bool> filter);

        UResponse Request<TRequest, UResponse>(TRequest request);
        Task<UResponse> RequestAsync<TRequest, UResponse>(TRequest request);

        void Respond<TRequest, UResponse>(Func<TRequest, UResponse> handler);
        void Respond<TRequest, UResponse>(Func<TRequest, UResponse> handler, Func<TRequest, bool> filter);
        Task RespondAsync<TRequest, UResponse>(Func<TRequest, Task<UResponse>> handler);
        Task RespondAsync<TRequest, UResponse>(Func<TRequest, Task<UResponse>> handler, Func<TRequest, bool> filter);
    }
}
