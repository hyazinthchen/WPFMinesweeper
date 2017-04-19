using System;

namespace WPFMinesweeper
{
    /// <summary>
    /// Interface für den EventBus
    /// </summary>
    public interface IEventBus {

        //TMessage = Typ der Message die verschickt wird
        void Subscribe<TMessage>(Action<TMessage> handler);
        void Unsubscribe<TMessage>(Action<TMessage> handler);
        void Publish<TMessage>(TMessage message);
    }
    
}
