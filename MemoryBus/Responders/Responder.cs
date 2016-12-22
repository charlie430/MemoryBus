﻿namespace MemoryBus
{
    using System;

    internal class Responder<T, U> : ResponderBase<T>, IDisposable
    {
        private Func<T, U> _responder;
        internal Responder(Func<T, U> responder, Func<T, bool> filter)
            : base(filter)
        {
            if (responder == null)
                throw new ArgumentNullException("Responder cannot be null");

            _responder = responder;
        }

        public U Respond(T message) => _responder(message);

        public void Dispose() => _responder = null;
    }
}