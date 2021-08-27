﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CameraControl : MonoBehaviour
{

	public GameObject close1;
	public GameObject close2;
	public GameObject open1;

    private Text m_MyText;           //字体组件

    void Start() 
	{
        close1.SetActive(false);
        close2.SetActive(false);
        open1.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState= CursorLockMode.Confined;
        GameObject root = GameObject.Find("Canvas");
        m_MyText = root.transform.Find("Image/Text").GetComponent<Text>();
        m_MyText.text = "滑动滚轮调整铁板间隙\n按E进入除杂";
    }
}