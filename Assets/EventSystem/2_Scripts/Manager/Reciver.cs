using ARWayKit.SDK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciver : MonoBehaviour
{
   
    private void OnEnable()
    {
        EventManager<Data>.StartListening("CallEvent", EventReciver);
    }

    private void OnDisable()
    {
        EventManager<Data>.StopListening("CallEvent", EventReciver);
    }

    private void EventReciver(Data obj)
    {
        Debug.Log("<color=green> Event Trigger *******"+obj.dataValue);
    }
}
