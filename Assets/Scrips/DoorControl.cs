using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl: MonoBehaviour
{

    private Animation ani;

    // Start is called before the first frame update
    void Start()
    {
        //得到第一个子物体的动画控件
        ani = transform.GetChild(0).GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ani.Play("OpenDoor");
    }

    private void OnTriggerExit(Collider other)
    {
        ani.Play("CloseDoor");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
