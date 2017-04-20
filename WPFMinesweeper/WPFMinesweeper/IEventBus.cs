using System;

namespace WPFMinesweeper {
    /// <summary>
    ///     Interface für den EventBus
    /// </summary>
    public interface IEventBus {
        void Publish<TMessage>(TMessage message);
        //TMessage = Typ der Message die verschickt wird
        Action<TMessage> Subscribe<TMessage>(Action<TMessage> handler);
        void Unsubscribe<TMessage>(Action<TMessage> handler);
    }
}