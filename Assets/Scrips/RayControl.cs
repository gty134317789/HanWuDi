using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//射线碰到第一个物体是时候会消失，返回物体信息

public class RayControl : MonoBehaviour
{
    //定义一个transform类的tr
    public Transform tr;
    public GameObject video_play;//获取播放面板物体

    public GameObject Cloth;   //防护服
    public GameObject Glove;   //防护手套

    private VideoControl vc;
    void Start()
    {
        //获取tr的component，后面输出要用
        tr = GetComponent<Transform>();
        vc = video_play.GetComponent<VideoControl>();//获取video player组件
        Cloth = GameObject.Find("防护服");    //获取防护服
        Glove = GameObject.Find("防护手套");  //获取防护手套
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
            if (Physics.Raycast(tr.position, tr.forward, out hit, 2.0f, LayerMask.GetMask("ColliderCube")))
            {
                Debug.Log("射线击中:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);
                if(hit.collider.gameObject.name== "Button_play")//判断射线是否碰撞了"播放/暂停"开关
                {
                    vc.OnplayorpauseVideo();
                }
                if (hit.collider.gameObject.name == "Button_pre")//判断射线是否碰撞了"上一个"开关
                {
                    vc.OnpreVideo();
                }
                if (hit.collider.gameObject.name == "Button_next")//判断射线是否碰撞了"下一个"开关
                {
                    vc.OnnextVideo();
                }
                if (hit.collider.gameObject.name == "防护服")//判断射线是否碰撞了防护服，然后消失
                {
                    Cloth.SetActive(false);
                }
                if (hit.collider.gameObject.name =="防护手套")//判断射线是否碰撞了防护手套，然后消失
                {
                    Glove.SetActive(false);
                }
            }
        }
    }
}



