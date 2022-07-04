using ARWayKit.SDK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reciver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        EventManager.StartListening("CallEvent", EventReciver);
    }

    private void OnDisable()
    {
        EventManager.StopListening("CallEvent", EventReciver);
    }

    private void EventReciver(EventData obj)
    {
        Debug.Log("<color=green> Event Trigger *******");
    }
}
