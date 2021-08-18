using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEquipment : MonoBehaviour
{
    public Transform tr;
    public int ScoreOfCheck; //存储清点设备阶段分数
    public Collider ElectricBox;  //电箱
    Collider WeldingTorch;  //焊枪
    Collider WeldingClamp;  //夹子
    Collider WeldingMachine; //电焊机
    Collider Dashboard_1;  //仪表盘1
    Collider Dashboard_2;  //仪表盘2
    Collider Wire;  //电线
    Collider Weldingrod_1;  //焊条1
    Collider Weldingrod_2;  //焊条2
    Collider Weldingrod_3;  //焊条3
    Collider SteelPlate_1;  //钢板1
    Collider SteelPlate_2;  //钢板2
    Collider Sandpaper_1;   //砂纸1
    Collider Sandpaper_2;   //砂纸2
    Collider Light;         //台灯

    void Start()
    {
        
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
                //击中后识别目标，并进行加分逻辑
                if (hit.collider.gameObject.name == "电箱")
                {
                    ScoreOfCheck++;  //加1分
                    ElectricBox = GameObject.Find("电箱").GetComponent<Collider>();
                    ElectricBox.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "焊枪")
                {
                    ScoreOfCheck++;  //加1分
                    WeldingTorch = GameObject.Find("焊枪").GetComponent<Collider>();
                    WeldingTorch.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "夹子")
                {
                    ScoreOfCheck++;  //加1分
                    WeldingClamp = GameObject.Find("夹子").GetComponent<Collider>();
                    WeldingClamp.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "电焊机")
                {
                    ScoreOfCheck++;  //加1分
                    WeldingMachine = GameObject.Find("电焊机").GetComponent<Collider>();
                    WeldingMachine.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "仪表盘1")
                {
                    ScoreOfCheck++;  //加1分
                    Dashboard_1 = GameObject.Find("仪表盘1").GetComponent<Collider>();
                    Dashboard_1.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "仪表盘2")
                {
                    ScoreOfCheck++;  //加1分
                    Dashboard_2 = GameObject.Find("仪表盘2").GetComponent<Collider>();
                    Dashboard_2.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "电线")
                {
                    ScoreOfCheck++;  //加1分
                    Wire = GameObject.Find("电线").GetComponent<Collider>();
                    Wire.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "焊条1")
                {
                    ScoreOfCheck++;  //加1分
                    Weldingrod_1 = GameObject.Find("焊条1").GetComponent<Collider>();
                    Weldingrod_1.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "焊条2")
                {
                    ScoreOfCheck++;  //加1分
                    Weldingrod_2 = GameObject.Find("焊条2").GetComponent<Collider>();
                    Weldingrod_2.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "焊条3")
                {
                    ScoreOfCheck++;  //加1分
                    Weldingrod_3 = GameObject.Find("焊条3").GetComponent<Collider>();
                    Weldingrod_3.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "焊板1")
                {
                    ScoreOfCheck++;  //加1分
                    SteelPlate_1 = GameObject.Find("焊板1").GetComponent<Collider>();
                    SteelPlate_1.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "焊板2")
                {
                    ScoreOfCheck++;  //加1分
                    SteelPlate_2 = GameObject.Find("焊板2").GetComponent<Collider>();
                    SteelPlate_2.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "砂纸1")
                {
                    ScoreOfCheck++;  //加1分
                    Sandpaper_1 = GameObject.Find("砂纸1").GetComponent<Collider>();
                    Sandpaper_1.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "砂纸2")
                {
                    ScoreOfCheck++;  //加1分
                    Sandpaper_2 = GameObject.Find("砂纸2").GetComponent<Collider>();
                    Sandpaper_2.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }

                if (hit.collider.gameObject.name == "台灯")
                {
                    ScoreOfCheck++;  //加1分
                    Light = GameObject.Find("台灯").GetComponent<Collider>();
                    Light.enabled = false;
                    Debug.Log(ScoreOfCheck);
                }
            }
        }
    }
}
