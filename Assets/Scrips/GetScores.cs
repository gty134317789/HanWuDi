using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScores : MonoBehaviour
{
    int num_Ball;//已除杂小球数（n/11)
    int num_Mask;//未带面罩次数
    float time_Weld;//异常焊接时间
    //int num_JPG;//红色像素点个数（）
    // Start is called before the first frame update
    public void GetScore()
    {
        GameObject mouse_position =GameObject.Find("鼠标世界位置");
        num_Ball = mouse_position.GetComponent<DestroyImpurities>().ScoreOfDestory;
        num_Mask = mouse_position.GetComponent<WeldControl>().num_pp2;
        time_Weld = mouse_position.GetComponent<WeldControl>().n_Time;
        //num_JPG = GameObject.Find("焊缝判别辅助Cube").GetComponent<ChangeJPG>().sum_point;
        //Debug.Log("已除杂小球数" + num_Ball + "未带面罩次数" + num_Mask + "异常焊接时间" + time_Weld + "红色像素点" + num_JPG);
        Debug.Log("已除杂小球数" + num_Ball + "未带面罩次数" + num_Mask + "异常焊接时间" + time_Weld );
    }
}
