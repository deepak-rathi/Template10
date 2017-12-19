﻿using System;

namespace Template10.Services.Messenger
{
    public interface IMessengerAdapter
    {
        void Send<T>(T message);
        void Subscribe<T>(object subscriber, Action<T> callback);
        void Unsubscribe<T>(object subscriber, Action<T> callback);
        void Unsubscribe(object subscriber);
    }
}
