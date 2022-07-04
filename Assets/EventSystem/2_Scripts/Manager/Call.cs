using ARWayKit.SDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Data {

    public int dataValue;
}
public class Call : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CallEvent", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CallEvent() {
        EventManager<Data>.TriggerEvent("CallEvent", new Data() { dataValue = 10});
    }

}
