using System;
using System.Collections.Generic;
using System.Linq;

namespace WPFMinesweeper {
    public class EventBus : IEventBus {

        /// <summary>
        ///     Konstruktor für den EventBus
        /// </summary>
        public EventBus() {
            
        }

        /// <summary>
        ///     Speichert die Subscriber eines Events
        /// </summary>
        private readonly List<Delegate> _subscribers = new List<Delegate>();

        /// <summary>
        ///     Ruft gewünschte Events auf
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="message"></param>
        public void Publish<TMessage>(TMessage message) {
            if (message == null) {
                throw new NotImplementedException();
            }
            List<Action<TMessage>> compatibleHandlers = _subscribers.OfType<Action<TMessage>>().ToList();
            foreach (Action<TMessage> h in compatibleHandlers) {
                h(message);
            }
        }

        /// <summary>
        ///     Abonniert einen Eventhandler
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="handler"></param>
        public Action<TMessage> Subscribe<TMessage>(Action<TMessage> handler) {
            if (handler == null) {
                throw new ArgumentNullException(nameof(handler));
            }
            _subscribers.Add(handler);
            return handler;
        }

        /// <summary>
        ///     Kündigt das Abonnement eines Eventhandlers
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="handler"></param>
        public void Unsubscribe<TMessage>(Action<TMessage> handler) {
            if (handler == null) {
                throw new ArgumentNullException(nameof(handler));
            }
            _subscribers.Remove(handler);
        }
    }
}