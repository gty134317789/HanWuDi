using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOfPrepareRoom : MonoBehaviour
{
    public int scoreofprepareroom;
    public Transform tr;
    private string numofshow;
    public GameObject Cloth;   //防护服
    public GameObject Glove;   //防护手套
    public GameObject Viewswitch;
    public VideoControl num; 
    // Start is called before the first frame update
    void Start()
    {
        scoreofprepareroom = 0;
        Cloth = GameObject.Find("防护服");    //获取防护服
        Glove = GameObject.Find("防护手套");  //获取防护手套
        num = GameObject.Find("播放面板").GetComponent<VideoControl>();
    }

    // Update is called once per frame
    void Update()
    {

        //点击鼠标左键之后
        if (Input.GetMouseButtonDown(0))
        {
            //在Scene视图里面发射一条可视化射线
            //参数为tr的位置，tr方向向前，绿色
            Debug.DrawRay(tr.position, tr.forward * 4.0f, Color.green);
            //创建从摄像机发射到鼠标位置的射线，ray是起点，input是鼠标的坐标
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            //判断射线是否与游戏对象相交
            //位置、向前、发出射线、4m
            if (Physics.Raycast(tr.position, tr.forward, out hit, 4.0f, LayerMask.GetMask("ColliderCube")))
            {
                Debug.Log("射线击中:" + hit.collider.gameObject.name + "\n tag:" + hit.collider.tag);

                //击中后识别目标，并进行加分逻辑
                if (hit.collider.gameObject.name == "防护服")
                {
                    Cloth.SetActive(false);
                    scoreofprepareroom += 1;  //加1分
                    numofshow = scoreofprepareroom.ToString();
                    Debug.Log(scoreofprepareroom);
                }
                if (hit.collider.gameObject.name == "防护手套")
                {
                    Glove.SetActive(false);
                    scoreofprepareroom += 1;  //加1分
                    numofshow = scoreofprepareroom.ToString();
                    Debug.Log(scoreofprepareroom);
                }
                if (hit.collider.gameObject.name == "Button_play")//判断射线是否碰撞了"播放/暂停"开关
                {
                    num.OnplayorpauseVideo();
                }
                if (hit.collider.gameObject.name == "Button_pre")//判断射线是否碰撞了"上一个"开关
                {
                    num.OnpreVideo();
                }
                if (hit.collider.gameObject.name == "Button_next")//判断射线是否碰撞了"下一个"开关
                {
                    num.OnnextVideo();
                }
            }

            //播放视频得分
            if (num.Num==2) 
            {
                scoreofprepareroom += 2;//播放视频+2分
                numofshow = scoreofprepareroom.ToString();
                Debug.Log(scoreofprepareroom);
            }
        }
    }




}
