using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public float scrollSpeed = 10;//滑轮滚动速度
    private Transform player;//主角的位置变量
    private Vector3 offsetPosition; //位置偏移
    private float distance = 0;//位置偏移的向量长度

    public float dismix=0.5f;//摄像机距离最小值
    public float dismax=1.5f;//摄像机距离最大值

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag(Tags.player).transform;//找到主角的位置
        player = GameObject.FindGameObjectWithTag("Player").transform;//找到主角的位置
        offsetPosition = transform.position - player.position;
        //主角与摄像机之间的偏移
    }

    void Update()
    {
        //调用处理视野的拉近和拉远方法
        ScrollView();
    }

    private void ScrollView()
    {

        //向后滑动返回负值  向前滑动返回正值
        distance = offsetPosition.magnitude;//位置偏移的向量长度
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;//获取滚轮值的改变
        distance = Mathf.Clamp(distance, dismix, dismax);//限制滚轮距离的范围，此数值可根不同需求设置相应的值
        offsetPosition = offsetPosition.normalized * distance;  //单位向量  方向不变 距离改变
        transform.position = player.transform.position + offsetPosition;//更新摄像机位置
    }
}
