using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour
{
    private VideoPlayer videoplayer;
    private int currentClipIndex;//播放视频的序号
    private TextMesh text_playorpause;//按钮的显示内容（播放/暂停）
    bool control;//判断人物是否在触发器内

    public GameObject text_play;//获取3dtext物体
    public VideoClip[] videoClips;//定义了一个数组用于存放视频资源
 
    void Start()
    {
        videoplayer = this.GetComponent<VideoPlayer>();//获取video player组件
        currentClipIndex = 0;
        videoplayer.clip = videoClips[currentClipIndex];//将序号0视频作为第一个播放的视频
        control = false;
        text_playorpause = text_play.GetComponent<TextMesh>();//获取文字组件
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)//判断人物是否在触发范围内
    {
        control = true;
    }

    private void OnTriggerExit(Collider other)
    {
        control = false;

    }
    public void OnplayorpauseVideo()//
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
    public void OnpreVideo()//将待播放视频改为上个视频，并播放
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
    public void OnnextVideo()//将待播放视频改为下个视频，并播放
    {
        currentClipIndex += 1;
        currentClipIndex = currentClipIndex % videoClips.Length;
        videoplayer.clip = videoClips[currentClipIndex];
        text_playorpause.text = "暂停";
        OnplayorpauseVideo();
    }
}