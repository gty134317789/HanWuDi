using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;

public class Score_1 : MonoBehaviour
{
    public CheckEquipment  score;
    public Text Score;

    void Awake()
    {
        Score = GameObject.Find("计分板").GetComponent<Text>();
        score =GameObject.Find("FirstPersonCharacter").GetComponent<CheckEquipment>();
    }


    void Update()
    {
        Score.text = "得分："+score.ScoreOfCheck.ToString();
        //Debug.Log(score.ScoreOfCheck);
    }
}