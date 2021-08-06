using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//射线碰到第一个物体是时候会消失，返回物体信息

public class RayControl : MonoBehaviour
{
    //定义一个transform类的tr
    public Transform tr;
    void Start()
    {
        //获取tr的component，后面输出要用
        tr = GetComponent<Transform>();
    }


    void Update()
    {
        //点击鼠标左键之后
        if (Input.GetMouseButtonDown(0))
        {
            //在Scene视图里面发射一条可视化射线
            //参数为tr的位置，tr方向向前，绿色
            Debug.DrawRay(tr.position, tr.forward * 2.0f, Color.green);
            //创建从摄像机发射到鼠标位置的射线，ray是起点，input是鼠标的坐标
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            //判断射线是否与游戏对象相交
            //位置、向前、发出射线、2m
            if (Physics.Raycast(tr.position, tr.forward, out hit, 2.0f))
            {
                Debug.Log("射线击中:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);
            }
        }
    }
}



