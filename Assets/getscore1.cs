using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getscore1 : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("FirstPersonCharacter").GetComponent<ScoreOfPrepareRoom>().scoreofprepareroom;
        Debug.Log(score);
    }
}
