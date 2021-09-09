using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyImpurities : MonoBehaviour
{
    bool isDragging;//控制是否按下鼠标左键
    private bool collider_control;//控制在脚本激活时鼠标点击功能才启用
    private Collider ball;
    private int num;
    private Text m_MyText;           //字体组件

    private void Start()
    {
        collider_control = true;
        isDragging = false;
        num = 0;
        GameObject root = GameObject.Find("Canvas");
        m_MyText = root.transform.Find("Image/Text").GetComponent<Text>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))//按E进入下一步焊接流程
        {
            if (num >= 11)
            {
                GameObject mouseposition = GameObject.Find("鼠标世界位置");//激活焊接控制脚本
                mouseposition.GetComponent<WeldControl>().enabled = true;
                GameObject camera = GameObject.Find("焊接摄像头");//激活摄像机拉近脚本
                camera.GetComponent<MoveCamera>().enabled = true;
                GameObject ironplate = GameObject.Find("焊板");//激活焊板翻转脚本
                ironplate.GetComponent<Test_up_down>().enabled = true;
                collider_control = false;
                isDragging = false;
                this.enabled = false;//禁用本脚本
            }
            else
            {
                m_MyText.text = "还有杂质未被清除\n按E开始焊接";
            }
        }
    }
  
    void OnMouseDown()//点击小球时，若鼠标世界位置处于杂质小球内部，则删除小球
    {
        if (isDragging)//鼠标位置处于物体内
        {
            Destroy(ball.gameObject);
            num++;
            isDragging = false;
        }
    }
    void OnTriggerEnter(Collider other)//鼠标位置进入杂质小球
    {
        if (collider_control && other.tag == "杂质")
        {
            isDragging = true;
            ball = other;
        }
    }
    void OnTriggerExit(Collider other)//鼠标位置离开杂质小球
    {
        if (collider_control)
            isDragging = false;
    }

}
