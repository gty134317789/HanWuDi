using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class getscore1 : MonoBehaviour
{
    public int score;
    private string scenename;
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        scenename = SceneManager.GetActiveScene().name;
        if (scenename == "准备室" ) {
            score = GameObject.Find("FirstPersonCharacter").GetComponent<ScoreOfPrepareRoom>().scoreofprepareroom;
        }
    }
}
