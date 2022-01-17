using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreboardOfPrepareRoom : MonoBehaviour
{
    public ScoreOfPrepareRoom score;
    public Text Score;

    void Awake()
    {
        Score = GameObject.Find("焊接室计分板").GetComponent<Text>();
        score = GameObject.Find("FirstPersonCharacter").GetComponent<ScoreOfPrepareRoom>();
    }


    void Update()
    {
        Score.text = "得分：" + score.scoreofprepareroom.ToString();
        //Debug.Log(score.ScoreOfCheck);
    }
}