using System;
using System.Collections.Generic;
using UnityEngine;

namespace ARWayKit.SDK { 

public class EventData {
    public bool status = false;
}

    public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action<EventData>> eventDictionary;
    private static EventManager eventManager;

    public static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }
    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, Action<EventData>>();
        }
    }

     public static void StartListening (string eventName, Action<EventData> listener)
    {
        Action<EventData> thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent += listener;
        } 
        else
        {
            thisEvent += listener;
            instance.eventDictionary.Add (eventName, thisEvent);
        }
    }

    public static void StopListening (string eventName, Action<EventData> listener)
    {
        if (eventManager == null) return;
        Action<EventData> thisEvent;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent -= listener;
        }
    }

    public static void TriggerEvent (string eventName, EventData data)
    {
        Action<EventData> thisEvent = null;
        if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.Invoke (data);
        }
    }
}
}
