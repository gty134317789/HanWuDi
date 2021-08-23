using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);//得到摄像机的屏幕位置
        Vector3 mousePosOnScreen = Input.mousePosition;//得到鼠标的屏幕位置
        mousePosOnScreen.z = screenPos.z;//使鼠标的深度与摄像机深度相同，即处于同一X-Y坐标系
        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosOnScreen);//得到鼠标的世界位置

        transform.position = mousePosInWorld;//将空物体位置设为鼠标世界位置
        transform.position = new Vector3(transform.position.x, -2.82f, transform.position.z);//高度设置为焊板高度，便于焊接操作
    }
}
