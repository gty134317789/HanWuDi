using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SwitchView : MonoBehaviour
{

    public Animator transition;
    public float transitionTime=2f;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hello");
        StartCoroutine(LoadLevel(1));//参数只能为int

    }
    
    //创建携程播放动画
    IEnumerator LoadLevel(int levelIndex)
    {

        //播放相应动画
        transition.SetTrigger("Start");


        //等待
        yield return new WaitForSeconds(transitionTime);//停止这个携程等待一段时间后继续
        //加载新场景

        SceneManager.LoadScene(levelIndex);
    }
    private void OnTriggerExit(Collider other)
    {
       

    }

    //控制两次按E的时间间隔
    //
    //
   

    // Update is called once per frame
   
}

