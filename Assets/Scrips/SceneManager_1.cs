/*
 * 逻辑分两层
 * 第一层：检测有没有穿上防护服
 * 第二层：检测有没有播放过所有的视频
 * 两层逻辑都结束，开门进入下一个场景
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager_1 : MonoBehaviour
{
    //此处定义对应Start里面的操作，start里面不再赘述
    private GameObject cloth;        //获取防护服
    private GameObject glove;        //获取手套
    private GameObject videoplayer;  //获取视频播放器
    private DoorControl Point_2;     //定义第二层逻辑触发点
    public VideoControl num;         //获取计数器
    private Text m_MyText;           //字体组件
    void Start()
    {
        GameObject root = GameObject.Find("Canvas");
        m_MyText = root.transform.Find("Image/Text").GetComponent<Text>();
        m_MyText.text = "穿戴好防护装备";
        cloth = GameObject.Find("防护服");
        glove = GameObject.Find("防护手套");
        num = GameObject.Find("播放面板").GetComponent<VideoControl>();
        Point_2 = GameObject.Find("门").GetComponent<DoorControl>();
        videoplayer = GameObject.Find("播放面板");
        videoplayer.SetActive(false);            //一开始隐藏播放器
    }


    void Update()
    {
        FirstPoint();    //先调用第一层逻辑
        SecondPoint();   //再调用第二层逻辑
        Debug.Log(num.Num);
    }


    void FirstPoint() //第一层逻辑，调用的是VideoControl里面的函数
    {
        if (!cloth.activeInHierarchy && !glove.activeInHierarchy)  //这个函数是检测面板里面的物体可用状态，挺好用的一个函数
        {
            m_MyText.text = "观看视频";
            videoplayer.SetActive(true);
        }
    }

    void SecondPoint() //第二层逻辑，调用的是VideoControl和DoorControl里面的函数
    {
        if (num.Num >= 2)
        {
            m_MyText.text = "进入焊接室";
            Point_2.enabled = true;
        }
    }
}
