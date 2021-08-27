using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Test_up_down : MonoBehaviour
{
    // Start is called before the first frame update
    
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
            ani.SetBool("start", true);
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
        ani.SetBool("start", false);
        yield return new WaitForSeconds(1.8f);
        ani.SetBool("start", true);
        this.enabled = false;//禁用本脚本
    }
}
