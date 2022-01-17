using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckEquipment : MonoBehaviour
{
    public ScoreOfPrepareRoom scorebefore;
    private Text m_MyText;           //字体组件
    public Transform tr;
    public int ScoreOfCheck=0; //存储清点设备阶段分数
    public int ScoreOfBeforeWeld=0; //储存焊接前分数
    private Collider ElectricBox;  //电箱
    Collider WeldingTorch;  //焊枪
    GameObject WeldingClamp;  //夹子
    Collider WeldingMachine; //电焊机
    Collider Dashboard_1;  //仪表盘1
    Collider Dashboard_2;  //仪表盘2
    GameObject Wire;  //电线
    GameObject Weldingrod_1;  //焊条1
    GameObject Weldingrod_2;  //焊条2
    GameObject Weldingrod_3;  //焊条3
    GameObject SteelPlate_1;  //钢板1
    GameObject SteelPlate_2;  //钢板2
    GameObject Sandpaper_1;   //砂纸1
    GameObject Sandpaper_2;   //砂纸2
    Collider Light;         //台灯
    Collider Switch;        //开关
    Collider WireWelled;    //接好后的电线

    //定义两个数值，存放钢板数、焊条数和砂纸数
    int NumOfWeldinggrod;
    int NumOfSteelPlate;
    int NumOfSandpaper;

    private string num;

    GameObject Button_StartWeld;//开始焊接按钮

    //焊接前挑选的物品
    public GameObject ToWeldingrod_1;  //待用焊条1
    public GameObject ToWeldingrod_2;  //待用焊条2
    public GameObject ToWeldingrod_3;  //待用焊条3
    public GameObject ToSandpaper_1;   //待用砂纸1
    public GameObject ToSandpaper_2;   //待用砂纸2
    public GameObject ToWeldingplate_1;//待用焊板1
    public GameObject ToWeldingplate_2;//待用焊板2

    //private Text m_MyText;           //字体组件


    void Start()
    {
        ScoreOfCheck = GameObject.Find("上一场景的分数").GetComponent<getscore1>().score;
        Debug.Log("准备室的分数是："+ScoreOfCheck);
        GameObject root = GameObject.Find("Canvas");
        m_MyText=root.transform.Find("Image/Text").GetComponent<Text>();
        m_MyText.text = "点击物品清点15个设备\n点击按钮即可开始焊接";
        string num = ScoreOfCheck.ToString();
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
                    ScoreOfCheck+=10;  //加1分
                    num = ScoreOfCheck.ToString();
                    ElectricBox = GameObject.Find("电箱").GetComponent<Collider>();
                    ElectricBox.enabled = false;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "电箱已清点\n"+ num+"-15";

                }

                if (hit.collider.gameObject.name == "焊枪")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    WeldingTorch = GameObject.Find("焊枪").GetComponent<Collider>();
                    WeldingTorch.enabled = false;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "焊枪已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "夹子")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    WeldingClamp = GameObject.Find("夹子");
                    WeldingClamp.SetActive(false);
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "夹子已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "电焊机")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    WeldingMachine = GameObject.Find("电焊机").GetComponent<Collider>();
                    WeldingMachine.enabled = false;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "电焊机已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "仪表盘1")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Dashboard_1 = GameObject.Find("仪表盘1").GetComponent<Collider>();
                    Dashboard_1.enabled = false;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "仪表盘1已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "仪表盘2")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Dashboard_2 = GameObject.Find("仪表盘2").GetComponent<Collider>();
                    Dashboard_2.enabled = false;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "仪表盘2已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "电线")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Wire = GameObject.Find("电线");
                    Wire.SetActive(false);
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "电线已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "焊条1")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Weldingrod_1 = GameObject.Find("焊条1");
                    Weldingrod_1.SetActive(false);
                    ToWeldingrod_1.SetActive(true);
                    NumOfWeldinggrod++;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "焊条1已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "焊条2")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Weldingrod_2 = GameObject.Find("焊条2");
                    Weldingrod_2.SetActive(false);
                    ToWeldingrod_2.SetActive(true);
                    NumOfWeldinggrod++;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "焊条2已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "焊条3")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Weldingrod_3 = GameObject.Find("焊条3");
                    Weldingrod_3.SetActive(false);
                    ToWeldingrod_3.SetActive(true);
                    NumOfWeldinggrod++;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "焊条3已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "焊板1")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    SteelPlate_1 = GameObject.Find("焊板1");
                    SteelPlate_1.SetActive(false);
                    ToWeldingplate_1.SetActive(true);
                    NumOfSteelPlate++;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "焊板1已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "焊板2")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    SteelPlate_2 = GameObject.Find("焊板2");
                    SteelPlate_2.SetActive(false);
                    ToWeldingplate_2.SetActive(true);
                    NumOfSteelPlate++;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "焊板2已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "砂纸1")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Sandpaper_1 = GameObject.Find("砂纸1");
                    Sandpaper_1.SetActive(false);
                    ToSandpaper_1.SetActive(true);
                    NumOfSandpaper++;
                    Debug.Log(ScoreOfCheck);
                    m_MyText.text = "砂纸1已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "砂纸2")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Sandpaper_2 = GameObject.Find("砂纸2");
                    Sandpaper_2.SetActive(false);
                    ToSandpaper_2.SetActive(true);
                    NumOfSandpaper++;
                    Debug.Log(ScoreOfCheck.ToString());
                    m_MyText.text = "砂纸2已清点\n" + num + "-15";
                }

                if (hit.collider.gameObject.name == "台灯")
                {
                    ScoreOfCheck++;  //加1分
                    num = ScoreOfCheck.ToString();
                    Light = GameObject.Find("台灯").GetComponent<Collider>();
                    Light.enabled = false;
                    Debug.Log(ScoreOfCheck.ToString() + NumOfSandpaper.ToString() + NumOfSteelPlate.ToString() + NumOfWeldinggrod.ToString());
                    m_MyText.text = "台灯已清点\n" + num + "-15";
                }
                if (hit.collider.gameObject.name == "开始焊接按钮")
                {
                    Button_StartWeld = GameObject.Find("开始焊接按钮");
                    Button_StartWeld.GetComponent<CameraControl>().enabled = true;
                    Debug.Log("开始焊接");
                }

                //如果设备清点完，进入焊接前计分
                if (ScoreOfCheck == 15 )
                {

                    if (hit.collider.gameObject.name == "开关底座") //打开开关
                    {
                        GameObject.Find("开关底座").GetComponent<HighlightableObject>().enabled = false;
                        GameObject.Find("开关底座").GetComponent<Collider>().enabled = false;
                        ScoreOfBeforeWeld++;
                        Debug.Log(ScoreOfBeforeWeld+ScoreOfCheck);
                    }

                    if(hit.collider.gameObject.name == "夹子(夹好后)") //夹子接地
                    {
                        GameObject.Find("夹子(夹好后)").GetComponent<HighlightableObject>().enabled = false;
                        GameObject.Find("夹子(夹好后)").GetComponent<Collider>().enabled = false;
                        ScoreOfBeforeWeld++;
                    }

                    if (hit.collider.gameObject.name == "电线(接好状态)")  //接线
                    {
                        GameObject.Find("电线(接好状态)").GetComponent<HighlightableObject>().enabled = false;
                        GameObject.Find("电线(接好状态)").GetComponent<Collider>().enabled = false;
                        ScoreOfBeforeWeld++;
                    }

                    if(hit.collider.gameObject.name == "台灯开关") //打开台灯
                    {
                        GameObject.Find("台灯开关").GetComponent<HighlightableObject>().enabled = false;
                        GameObject.Find("台灯开关").GetComponent<Collider>().enabled = false;
                        ScoreOfBeforeWeld++;
                    }
                }
            }
        }
    }




}
