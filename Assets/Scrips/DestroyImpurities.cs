using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyImpurities : MonoBehaviour
{
    bool isDragging;//控制是否按下鼠标左键
    private bool mouse_control;//控制在脚本激活时鼠标点击功能才启用

    private void Start()
    {
        mouse_control = true;
        isDragging = false;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))//按E进入下一步焊接流程
        {
            GameObject mouseposition = GameObject.Find("鼠标世界位置");//激活焊接控制脚本
            mouseposition.GetComponent<WeldControl >().enabled = true;
            GameObject camera = GameObject.Find("焊接摄像头");//激活摄像机拉近脚本
            camera.GetComponent<MoveCamera>().enabled = true;
            this.enabled = false;//禁用本脚本
        }
    }
    private void OnMouseDown()//判断是否按下鼠标
    {
        if (mouse_control)
        {
            isDragging = true;
        }
    }
    private void OnMouseUp()//判断是否松开鼠标
    {
        if (mouse_control)
        {
            isDragging = false;
        }
    }
    void OnTriggerStay(Collider other)//与杂质小球碰撞时，若处于鼠标左键长按点击状态，则删除小球
    {
        if (other.tag == "杂质" )
        {
            if (isDragging)//处于鼠标长按状态
            Destroy(other.gameObject);
        }
    }
}
