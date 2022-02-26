using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorControl : MonoBehaviour
{
    //初始化animation并且初始化int变量控制动画播放
    private Animation ani;
    int num = 0;
    //控制函数controlpushE的执行
    bool control_E = false;

    DateTime startTime;
    DateTime startSpan;
    DateTime nowSpan;


    // Start is called before the first frame update
    void Start()
    {
        //得到第一个子物体的动画控件
        ani = transform.GetChild(0).GetComponent<Animation>();
    }
    //直接利用触发器来启动动画
    //private void OnTriggerEnter(Collider other)
    //{
    //    ani.Play("OpenDoor");
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    ani.Play("CloseDoor");
    //}

    //必须站在触发器内按E才有反应
    private void OnTriggerEnter(Collider other)
    {
        GameObject root_1 = GameObject.Find("3DText");
        GameObject Text_E = root_1.transform.Find("PushE").gameObject;
        Text_E.SetActive(true);
        control_E = true;

    }
    private void OnTriggerExit(Collider other)
    {
        GameObject root_1 = GameObject.Find("3DText");
        GameObject Text_E = root_1.transform.Find("PushE").gameObject;
        Text_E.SetActive(false);
        control_E = false;

    }

    //控制两次按E的时间间隔
   //
   //
    public void ControlpushE()
    {
        if(control_E==true)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                //将3d文字缩小到0，已达到文字只出现一次，按E后不再出现的效果
                GameObject root_1 = GameObject.Find("3DText");
                GameObject Text_E = root_1.transform.Find("PushE").gameObject;
                Text_E.transform.localScale = new Vector3(0, 0,0);
                // Destroy(Text_E);重复使用，destory同一物体会导致程序暂停

                if (num % 2 == 0 )
                {

                    ani.Play("OpenDoor");
                    Debug.Log(num);
                }
                else 
                {
                    ani.Play("CloseDoor");
                    Debug.Log(num);
                }
                num++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ControlpushE();
    }
}
