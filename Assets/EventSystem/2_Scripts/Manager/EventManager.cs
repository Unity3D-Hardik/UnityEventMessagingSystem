using System;
using System.Collections.Generic;

/// <summary>
/// Created By Hardik Shah
/// https://github.com/Unity3D-Hardik/UnityEventMessagingSystem
/// </summary>

namespace HD.SDK
{
    public static class EventManager<T>
    {
        private static Dictionary<string, Action<T>> eventDictionary = new Dictionary<string, Action<T>>();

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
            Action<T> thisEvent;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent -= listener;
                eventDictionary.Remove(eventName);
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
