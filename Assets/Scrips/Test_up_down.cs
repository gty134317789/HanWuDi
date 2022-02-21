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
    public GameObject screenshot;//拍照组件物体


    //截图脚本
    public Camera mainCamera;
    public Camera uiCamera;
    int photonum = 1;
    /// <summary>  
    /// 对相机截图。   
    /// </summary>  
    /// <returns>The screenshot2.</returns>  
    /// <param name="camera">Camera.要被截屏的相机</param>  
    /// <param name="rect">Rect.截屏的区域</param>  
    void CaptureCamera(Camera camera, Camera camera2, Rect rect)
    {
        // 创建一个RenderTexture对象  
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, -1);
        // 临时设置相关相机的targetTexture为rt, 并手动渲染相关相机  
        camera.targetTexture = rt;
        camera.Render();
        //ps: --- 如果这样加上第二个相机，可以实现只截图某几个指定的相机一起看到的图像。  
        camera2.targetTexture = rt;
        camera2.Render();
        //ps: -------------------------------------------------------------------  

        // 激活这个rt, 并从中中读取像素。  
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素  
        screenShot.Apply();

        // 重置相关参数，以使用camera继续在屏幕上显示  
        camera.targetTexture = null;
        camera2.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors  
        GameObject.Destroy(rt);
        // 最后将这些纹理数据，成一个jpg图片文件  

        //无论截图多少次都只会保存一张图片
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.dataPath + "/Screenshot" + (photonum % 2).ToString() + ".jpg";//通过取余让截图覆盖，只存在Screenshot0.jpg和Screenshot1.jpg
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("截屏了一张照片: {0}", filename));


    }


    public void Getphoto()
    {
        photonum++;
        screenshot.SetActive(true);
        CaptureCamera(mainCamera, uiCamera, new Rect(0, 0, Screen.width, Screen.height));
        screenshot.SetActive(false);

    }
    void Start()
    {
        isAni = false;
        ani = GetComponent<Animator>();
        mouse_position = GameObject.Find("鼠标世界位置");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAni)
        {

            Getphoto();//调用截图

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
