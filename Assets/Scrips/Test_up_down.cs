using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Test_up_down : MonoBehaviour
{
    // Start is called before the first frame update
    int num = 1;
    private Animator ani;
    public GameObject mouse_position;//鼠标世界位置物体
    private bool isAni;//判断是否正在播放动画
    public GameObject PP1; //获取带有Postprocess volume组件的面罩特效
    public GameObject PP2; //获取带有Postprocess volume组件的光污染特效
    public GameObject button_iron;//焊接按钮

    void Start()
    {
        isAni = false;
        ani = GetComponent<Animator>();
        mouse_position = GameObject.Find("鼠标世界位置");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& !isAni)
        {
            isAni = true;//动画播放中状态
            mouse_position.SetActive(false);//禁用鼠标世界位置物体
            PP1.SetActive(false);
            PP2.SetActive(false);//禁用特效
            button_iron.SetActive(false);//禁用按钮

            // ani.SetInteger("NewStart", num);
            //有SetFloat函数但没有SetInt函数，得用SetInteger。。。。
            ani.Play("New State");
            ani.SetBool("start", true);
            if (num % 2 == 1)
            {
                ani.SetBool("choose", true);
            }
            else
            {
                ani.SetBool("choose", false);
            }
            StartCoroutine(PlayerAttack());

        }

    }
    //private void start_animation()
    //{
    //    yield return new WaitForSeconds(0.6f);
    //    //action();
    //}
    IEnumerator PlayerAttack()
    {


        yield return new WaitForSeconds(1.0f);
        // num=num+1;
        //ani.SetInteger("NewStart", num);
        ani.SetBool("start", false);
        yield return new WaitForSeconds(1.8f);
        //num = num + 1;
        //ani.SetInteger("NewStart", num);
        ani.SetBool("start", true);
        yield return new WaitForSeconds(1.0f);

        //启用按钮和焊接功能，动画播放完成状态
        button_iron.SetActive(true);
        mouse_position.SetActive(true);
        isAni = false;
        num++;

        //ani.SetBool("start", false);
        //this.enabled = false;//禁用本脚本




    }
}
