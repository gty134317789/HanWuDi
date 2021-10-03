﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeldControl : MonoBehaviour
{

    private Text m_MyText;           //字体组件
    private GameObject testobject;//所有空物体的父空物体

    public GameObject prefab;//预制体小球本体
    public GameObject particle;//粒子效果
    public GameObject prefab1;//存放每次长按预制体小球的空物体本体
    public GameObject PP1; //获取带有Postprocess volume组件的面罩特效
    public GameObject PP2; //获取带有Postprocess volume组件的光污染特效


    public int maxNumber;//最大小球数
    public float timeInterval;//生成小球的间隔时间
    public float size=0.6f; //预制体小球大小

    bool isDragging=false;//判断鼠标是否长按
    int i = 0;//记录长按次数
    int num = 0;//记录按E次数

    private float m_Time = 0;//deltatime累加器
    private int meshNumber = 0;//已生成小球数
    private bool mouse_control;//控制在脚本激活时鼠标点击功能才启用
    private bool light_pollution=false;//判断光污染特特效是否开启中


    private void Start()
    {
        mouse_control = true;
        GameObject root = GameObject.Find("Canvas");
        m_MyText = root.transform.Find("Image/Text").GetComponent<Text>();
        m_MyText.text = "鼠标点击进行焊接\n滑动滚轮可调整视角\n空格翻转物体";
        GameObject fatherobject = GameObject.Find("焊板");
        testobject = GameObject.Instantiate(prefab1, Vector3.zero, prefab1.transform.rotation, fatherobject.transform);
    }

    void Update()
    {
        MouseDown();
        MouseUp();
        if (isDragging)//长按鼠标时
        {
            m_Time += Time.deltaTime;
            if (m_Time > timeInterval && meshNumber < maxNumber)//到达小球生成间隔
            {
                meshNumber++;
                GameObject.Instantiate(prefab, transform.position, Random.rotation, testobject.transform.GetChild(i));
                //生成小球克隆在鼠标当前世界位置，随机角度,父物体为负责管理当次长按的空物体克隆
                m_Time = 0;
            }
        }
        ControlpushE();
    }

    private void MouseDown()
    {
        if (mouse_control&& Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            particle.SetActive(true);//激活粒子效果
           
            //GameObject.Instantiate(prefab1, Vector3.zero, prefab1.transform.rotation, testobject.transform);
            GameObject.Instantiate(prefab1, Vector3.zero, prefab1.transform.rotation, testobject.transform);
    
            //生成带有网格合并脚本的空物体克隆，负责存放单次长按生成的小球，位置为(0,0,0)，父物体为testobject
            testobject.transform.GetChild(i).localScale = new Vector3(size, size, size);//改变空物体克隆的大小以改变子物体小球大小

            if((num%2)==0)//判断是否没戴面罩就焊接
            {
                PP2.SetActive(true);//激活光污染特效
                light_pollution = true;
            }
        }
    }
    private void MouseUp()
    {
        if (mouse_control&& Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            particle.SetActive(false);//粒子效果
            testobject.transform.GetChild(i).GetComponent<CombineMeshes>().enabled = true;//激活合并网格脚本
            i++;//记录长按次数

            if (light_pollution)//判断是否激活了光污染特效
            {
                PP2.SetActive(false);//关闭光污染特效
                light_pollution = false;
            }
        }
    }
    public void ControlpushE()//按E激活或禁用PostProcessing
    {
        if (Input.GetKeyDown(KeyCode.E))
        {   
            if (num % 2 == 0)
                PP1.SetActive(true);
            else
                PP1.SetActive(false);
            num++;
        }
    }
}
