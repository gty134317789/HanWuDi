using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeldControl : MonoBehaviour
{

    private Text m_MyText;           //字体组件
    private GameObject testobject;//所有空物体的父空物体
    private GameObject fatherobject;//焊板

    public GameObject prefab;//预制体小球本体
    public GameObject particle;//粒子效果
    public GameObject prefab1;//存放每次长按预制体小球的空物体本体
    public GameObject PP1; //获取带有Postprocess volume组件的面罩特效
    public GameObject PP2; //获取带有Postprocess volume组件的光污染特效
    public GameObject button_iron;//焊接按钮
    public GameObject screenshot;//拍照组件物体
    public GameObject open1;
    public GameObject open2;
    public GameObject destory1;

    public int maxNumber=50;//最大小球数（每个子物体存放克隆小球数）
    public int maxSpeed=30;//鼠标最大移动速度
    public float timeInterval;//生成小球的间隔时间
    public float size=0.6f; //预制体小球大小

    int i = 0;//记录长按次数
    int num_reset = 3;//记录剩余复位次数
    int num = 0;//记录按E次数
    Vector3 v1;//当前位置

    private float m_Time = 0;//deltatime累加器
    private int meshNumber = 0;//已生成小球数
    private bool mouse_control;//控制在脚本激活时鼠标点击功能才启用
    private bool mouse_move;//控制鼠标移动是否规范
    private bool mouse_range;//控制鼠标移动范围
    private bool collider_control;//控制是否能碰撞
    private bool isResetting;//判断是否在复位按钮
    private bool isQuiting;//判断是否在退出按钮
    private bool isDragging;//判断鼠标是否长按
    private void Start()
    {
        //初始化鼠标位置与控制量
        collider_control = true;
        mouse_control = true;
        isResetting = false;
        isDragging = false;
        v1 = this.transform.position;

        GameObject root = GameObject.Find("Canvas");
        m_MyText = root.transform.Find("Image/Text").GetComponent<Text>();
        m_MyText.text = "鼠标点击进行焊接\n滑动滚轮可调整视角\n空格翻转物体";
        fatherobject = GameObject.Find("焊板");
        GameObject screenshot = GameObject.Find("焊缝判别辅助Cube");


    button_iron.SetActive(true);//显示复位按钮和退出按钮

        //初始化生成父物体与第一个子物体，并调整该子物体大小
        testobject = GameObject.Instantiate(prefab1, Vector3.zero, prefab1.transform.rotation, fatherobject.transform);
        GameObject.Instantiate(prefab1, Vector3.zero, prefab1.transform.rotation, testobject.transform);
        testobject.transform.GetChild(i).localScale = new Vector3(size, size, size);
    }

    void Update()
    {
        MouseDown();
        MouseUp();
        MousePosition();
        BallCreate();
        ControlpushE();
        ResetIron();
        QuitWeld();
    }

    private void BallCreate() //生成小球相关函数，功能：在第i个子物体下按固定间隔时间生成小球、每生成maxNumber个小球合并一次网格，并生成新的子物体
    {
        if (isDragging && mouse_move)//长按鼠标时
        {
            m_Time += Time.deltaTime;
            if (m_Time > timeInterval)//到达小球生成间隔
            {
                meshNumber++;
                GameObject.Instantiate(prefab, transform.position, Random.rotation, testobject.transform.GetChild(i));
                //生成小球克隆在鼠标当前世界位置，随机角度,父物体为负责管理当次长按的空物体克隆
                m_Time = 0;
            }
            if(meshNumber > maxNumber)//第i个子物体下的小球数达到最大值
            {
                testobject.transform.GetChild(i).GetComponent<CombineMeshes>().enabled = true;//激活合并网格脚本
                GameObject.Instantiate(prefab1, Vector3.zero, prefab1.transform.rotation, testobject.transform);
                //生成带有网格合并脚本的空物体克隆，负责存放单次长按生成的小球，位置为(0,0,0)，父物体为testobject
                i++;//记录合并次数
                testobject.transform.GetChild(i).localScale = new Vector3(size, size, size);//改变空物体克隆的大小以改变子物体小球大小
                meshNumber = 0;//重新计数
            }

        }
    }
    private void MousePosition()//判断鼠标移动是否符合规范，包括鼠标移动速度限制和移动范围限制
                                //v1记录上一帧位置 v2记录这一帧位置 计算得到mouse_speed即鼠标移动速度
                                //mouse_range 鼠标是否在焊板范围内   mouse_move 鼠标移动是否符合规范
    {
        Vector3 v2 = this.transform.position;//记录这一帧的位置
        float mouse_speed = Vector3.Distance(v1, v2) * 100 / Time.deltaTime;//计算速度
        v1 = v2;

        //Debug.Log("speed:"+mouse_speed);

        if (v2.x > -11.470f || v2.x < -11.812f || v2.z > -3.472f || v2.z < -3.995f)//鼠标不在焊板范围内
            mouse_range = false;
        else
            mouse_range = true;

        if (mouse_speed<maxSpeed&&mouse_range)//鼠标速度合适且位置合适，即移动符合规范
        {
            mouse_move = true;
            if(isDragging)
                particle.SetActive(true);//启用可能被本函数禁止的焊接特效

        }
        else
        {
            mouse_move = false;
            particle.SetActive(false);//鼠标移动不符合规范则禁止焊接特效
        }
    }
    private void MouseDown()//鼠标点下触发函数，功能：点击鼠标触发粒子效果和可能的光污染特效
                            //isDragging 鼠标是否按下 
    {
        if (mouse_control&& Input.GetMouseButtonDown(0)&&mouse_move)
        {
            isDragging = true;
            particle.SetActive(true);//激活粒子效果

            if((num%2)==0)//判断是否没戴面罩就焊接
            {
                PP2.SetActive(true);//激活光污染特效
            }
        }
    }
    private void MouseUp()
    {
        if (isDragging&& Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            particle.SetActive(false);//粒子效果
            PP2.SetActive(false);//关闭光污染特效
        }
    }
    public void ControlpushE()//按E激活或禁用PostProcessing
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (num % 2 == 0)
            {
                PP1.SetActive(true);
                PP2.SetActive(false);
            }
            else
            {
                PP1.SetActive(false);
                if(isDragging&&mouse_move)
                    PP2.SetActive(true);
            }
            num++;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (collider_control && other.tag == "reset")//鼠标进入复位按钮
        {
            //Debug.Log("enter collider");

            isResetting = true;
        }
        if (collider_control && other.tag == "quit")//鼠标进入退出按钮
        {
            //Debug.Log("enter collider");

            isQuiting = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (collider_control && other.tag == "reset")//鼠标离开复位按钮
        {
            //Debug.Log("exit collider");

            isResetting = false;
        }
        if (collider_control && other.tag == "quit")//鼠标离开退出按钮
        {
            //Debug.Log("exit collider");

            isQuiting = false;
        }
    }

    void ResetIron()//复位焊板功能，功能：删除已有的所有焊接小球并重新初始化、最多复位三次
    {
        if(isResetting && Input.GetMouseButtonDown(0)&& num_reset>0)//鼠标在复位按钮内点击，且存在复位次数
        {
            //Debug.Log("Reset Iron");

            Destroy(testobject.gameObject);
            num_reset--;

            //删除已有的所有焊接小球并重新初始化
            testobject = GameObject.Instantiate(prefab1, Vector3.zero, prefab1.transform.rotation, fatherobject.transform);
            GameObject.Instantiate(prefab1, Vector3.zero, prefab1.transform.rotation, testobject.transform);
            i = 0;
            testobject.transform.GetChild(i).localScale = new Vector3(size, size, size);
        }
    }
    void QuitWeld() 
    {
        if (isQuiting && Input.GetMouseButtonDown(0))
        {
            //关闭部分功能及组件
            PP1.SetActive(false);
            PP2.SetActive(false);
            fatherobject.GetComponent<Test_up_down>().enabled = false;

            //拍照计算空隙
            screenshot.SetActive(true);
            screenshot.GetComponent<ScreenShot>().enabled = true;
            screenshot.GetComponent<ChangeJPG>().enabled = true;

            //激活准星及人物
            open1.SetActive(true);
            open2.SetActive(true);
            Cursor.visible = false;

            //销毁焊接组件，延时1s（用于拍照计算）
            Destroy(destory1,1.0f);
        }
    }
}
