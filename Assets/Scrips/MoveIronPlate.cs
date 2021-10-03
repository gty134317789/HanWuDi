using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveIronPlate : MonoBehaviour
{

    private float scrollSpeed = 0.02f;//滑轮滚动速度
    private Transform player;//主角的位置变量
    private Vector3 offsetPosition; //位置偏移
    private float distance = 0;//位置偏移的向量长度

    private Text m_MyText;           //字体组件

    private float dismix = 0.129f;//焊板最近距离
    private float dismax = 0.150f;//焊板最远距离

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag(Tags.player).transform;//找到主角的位置
        player = GameObject.FindGameObjectWithTag("Player").transform;//找到主角的位置
        offsetPosition = transform.position - player.position;
  
        GameObject root = GameObject.Find("Canvas");
        m_MyText = root.transform.Find("Image/Text").GetComponent<Text>();//获取提示text
    }

    void Update()
    {
        
        ScrollView();//调用处理视野的拉近和拉远方法
        
        if (distance <= 0.141f && distance >= 0.132f)//焊板处于焊接的合适距离，则可进入下一步除杂
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
        //Debug.Log(distance);
        offsetPosition = offsetPosition.normalized * distance;  //单位向量  方向不变 距离改变
        transform.position = player.transform.position + offsetPosition;
        transform.position = new Vector3(transform.position.x, -2.485f, transform.position.z);
    }
    private void TrueScope()//进入下一步除杂流程
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            GameObject Mouseposition  = GameObject.Find("鼠标世界位置");
            Mouseposition.GetComponent<DestroyImpurities>().enabled = true;//激活除杂脚本
            this.enabled = false;//禁用本脚本
        }
    }
}