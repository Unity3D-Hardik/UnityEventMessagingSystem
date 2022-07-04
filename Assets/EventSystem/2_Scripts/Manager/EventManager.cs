using System;
using System.Collections.Generic;
using UnityEngine;

namespace ARWayKit.SDK
{
    public class EventManager<T>
    {
        private static Dictionary<string, Action<T>> eventDictionary = new Dictionary<string, Action<T>>();
       
        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, Action<T>>();
            }
        }

        public static void StartListening(string eventName, Action<T> listener)
        {
            Action<T> thisEvent = null;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent += listener;
            }
            else
            {
                thisEvent += listener;
                eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, Action<T> listener)
        {
            //if (eventManager == null) return;

            Action<T> thisEvent;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent -= listener;
            }
        }

        public static void TriggerEvent(string eventName, T data)
        {
            Action<T> thisEvent = null;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke(data);
            }
        }
    }
}
