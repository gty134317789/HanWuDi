using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个脚本用来控制人物，对学生的控制都写在这个里面
public class StudentContol : MonoBehaviour
{
    public float speed = 5;   //行走速度为5
 
    void Start()
    {

    }

  
    void Update()
    {
        MoveByTraslate();
    }


    //控制行走
    void MoveByTraslate()
    {
        if (Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.UpArrow)) //前
        {
            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.DownArrow)) //后
        {
            this.transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.LeftArrow)) //左
        {
            this.transform.Translate(Vector3.right * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) //右
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow)) //右
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    //控制视角

}
