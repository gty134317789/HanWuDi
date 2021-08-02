using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    private VideoPlayer videoplayer;
    private int currentClipIndex;//播放视频的序号
    bool control;//判断人物是否在触发器内

    public TextMesh text_playorpause;//按钮的显示内容（播放/暂停）
    public VideoClip[] videoClips;//定义了一个数组用于存放视频资源
 
    void Start()
    {
        videoplayer = this.GetComponent<VideoPlayer>();//获取video player组件
        currentClipIndex = 0;
        videoplayer.clip = videoClips[currentClipIndex];//将序号0视频作为第一个播放的视频
        control = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (control ==true)//若人物在触发器内，则功能启用
        {
            Control_1();
            Control_2();
            Control_3();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        control = true;
    }

    private void OnTriggerExit(Collider other)
    {
        control = false;

    }
    private void OnplayorpauseVideo()//
    {
        if (videoplayer.enabled == true)//判断是否有视频待播放
        {
            if (videoplayer.isPlaying)//若视频正在播放，则将暂停视频，并按钮上文字改为暂停
            {
                videoplayer.Pause();
                text_playorpause.text = "播放";
                Debug.Log("2322");//用于调试脚本不能正常运行

            }
            else if (!videoplayer.isPlaying)
            {
                videoplayer.Play();
                Debug.Log("111");
                text_playorpause.text = "暂停";
            }
        }
    }
    private void OnpreVideo()//将待播放视频改为上个视频，并播放
    {
        currentClipIndex -= 1;
        if (currentClipIndex < 0)
        {
            currentClipIndex = videoClips.Length - 1;
        }
        videoplayer.clip = videoClips[currentClipIndex];
        text_playorpause.text = "暂停";
        OnplayorpauseVideo();
    }
    private void OnnextVideo()//将待播放视频改为下个视频，并播放
    {
        currentClipIndex += 1;
        currentClipIndex = currentClipIndex % videoClips.Length;
        videoplayer.clip = videoClips[currentClipIndex];
        text_playorpause.text = "暂停";
        OnplayorpauseVideo();
    }

    public void Control_1()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            OnplayorpauseVideo();
    }
    public void Control_2()
    {
        if (Input.GetKeyUp(KeyCode.Alpha2))
            OnpreVideo();
    }
    public void Control_3()
    {
        if (Input.GetKeyUp(KeyCode.Alpha3))
            OnnextVideo();
    }
}