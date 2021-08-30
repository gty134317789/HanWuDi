﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveIronPlate : MonoBehaviour
{

    public float scrollSpeed = 0.05f;//滑轮滚动速度
    private Transform player;//主角的位置变量
    private Vector3 offsetPosition; //位置偏移
    private float distance = 0;//位置偏移的向量长度

    private Text m_MyText;           //字体组件

    public float dismix = 0.365f;//焊板最近距离
    public float dismax = 0.51f;//焊板最远距离

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag(Tags.player).transform;//找到主角的位置
        player = GameObject.FindGameObjectWithTag("Player").transform;//找到主角的位置
        offsetPosition = transform.position - player.position;
        //
        //
        GameObject root = GameObject.Find("Canvas");
        m_MyText = root.transform.Find("Image/Text").GetComponent<Text>();
        m_MyText.text = "点击按钮开始焊接";
    }

    void Update()
    {
        
        ScrollView();//调用处理视野的拉近和拉远方法
        
        if (distance <= 0.40f && distance >= 0.37f)//焊板处于焊接的合适距离，则可进入下一步除杂
        {
           
            TrueScope();
        }
    }

    private void ScrollView()
    {
        //向后滑动返回负值  向前滑动返回正值
        distance = offsetPosition.magnitude;//位置偏移的向量长度
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;//获取滚轮值的改变
        distance = Mathf.Clamp(distance, dismix, dismax);//限制滚轮距离的范围，此数值可根不同需求设置相应的值
        offsetPosition = offsetPosition.normalized * distance;  //单位向量  方向不变 距离改变
        transform.position = player.transform.position + offsetPosition;
        transform.position = new Vector3(transform.position.x, -2.845f, transform.position.z);
    }
    private void TrueScope()//进入下一步除杂流程
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            GameObject Mouseposition  = GameObject.Find("鼠标世界位置");//激活除杂脚本
            Mouseposition.GetComponent<DestroyImpurities>().enabled = true;
            m_MyText.text = "鼠标点击清除铁板上的杂质\n再次按E开始焊接";
            this.enabled = false;//禁用本脚本
        }
    }
}