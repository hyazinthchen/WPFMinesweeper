using System;
using System.Collections.Generic;

namespace WPFMinesweeper
{
    public class EventBus : IEventBus
    {
        /// <summary>
        /// Speichert die Subscriber eines Events
        /// </summary>
        private readonly Dictionary<Type, List<Object>> _subscribers = new Dictionary<Type, List<object>>();
        //Besser als Liste? Typ Delegate?


        /// <summary>
        /// Abonniert einen Eventhandler
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="handler"></param>
        public void Subscribe<TMessage>(Action<TMessage> handler)
        {
            //Wenn es schon eine Liste mit Subscribern für dieses Event gibt nutze diese, sonst lege neue an.
            if (_subscribers.ContainsKey(typeof(TMessage)))
            {
                var handlers = _subscribers[typeof(TMessage)];
                handlers.Add(handler);
            }
            else
            {
                var handlers = new List<Object>();
                handlers.Add(handler);
                _subscribers[typeof(TMessage)] = handlers;
            }
        }

        /// <summary>
        /// Kündigt das Abonnement eines Eventhandlers
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="handler"></param>
        public void Unsubscribe<TMessage>(Action<TMessage> handler)
        {
            //Wenn ein Subscriber unsubscriben will, muss er auch wirklich subscribed sein. Dann kann er von der Liste dieses Events entfernt werden.
            if (_subscribers.ContainsKey(typeof(TMessage)))
            {
                var handlers = _subscribers[typeof(TMessage)];
                handlers.Remove(handler);

                if (handlers.Count == 0)
                {
                    _subscribers.Remove(typeof(TMessage));
                }
            }
        }

        /// <summary>
        /// Ruft gewünschte Events auf
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="message"></param>
        public void Publish<TMessage>(TMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
