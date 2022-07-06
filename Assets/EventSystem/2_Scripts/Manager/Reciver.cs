using HD.SDK;
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
        Debug.Log("<color=green> Event Trigger ******* </color>"+obj.dataValue);
    }
}
