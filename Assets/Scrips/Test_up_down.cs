using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Test_up_down : MonoBehaviour
{
    // Start is called before the first frame update
    int num = 1;
    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

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
        num++;

        //ani.SetBool("start", false);
        //this.enabled = false;//禁用本脚本
    }
}
