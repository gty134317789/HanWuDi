using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyImpurities : MonoBehaviour
{
    private bool collider_control;//控制在脚本激活时鼠标点击功能才启用
    private Collider ball;
    public int ScoreOfDestory;
    private Text m_MyText;           //字体组件
    private bool isDragger;
    private void Start()
    {
        isDragger = false;
        collider_control = true;
        ScoreOfDestory = 0;
        GameObject root = GameObject.Find("Canvas");
        m_MyText = root.transform.Find("Image/Text").GetComponent<Text>();
        m_MyText.text = "鼠标点击清除铁板上的杂质\n再次按E开始焊接";//修改提示
    }
    void Update()
    {
        Destoryball();
        if (Input.GetKeyUp(KeyCode.E))//按E进入下一步焊接流程
        {
            GameObject mouseposition = GameObject.Find("鼠标世界位置");//激活焊接控制脚本
            mouseposition.GetComponent<WeldControl>().enabled = true;
            GameObject camera = GameObject.Find("焊接摄像头");//激活摄像机拉近脚本
            camera.GetComponent<MoveCamera>().enabled = true;
            GameObject ironplate = GameObject.Find("焊板");//激活焊板翻转脚本
            ironplate.GetComponent<Test_up_down>().enabled = true;
            collider_control = false;
            this.enabled = false;//禁用本脚本

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (collider_control && other.tag == "杂质")
        {
            isDragger = true;
            ball = other;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (collider_control && other.tag == "杂质")
        {
            isDragger = false;
        }
    }
    void Destoryball()
    {
        if (isDragger && Input.GetMouseButtonDown(0))
        {
            Destroy(ball.gameObject);
            ScoreOfDestory++;
            m_MyText.text = "杂质已清除： " + ScoreOfDestory + " - 11\n再次按E开始焊接";
            isDragger = false;
        }
    }
}