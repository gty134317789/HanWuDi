using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class ChangeJPG : MonoBehaviour
{


    void Start()
    {
        Debug.Log(Application.dataPath);
        //程序主要功能由下面一行开始    
        StartCoroutine(Load("/Screenshot0.jpg"));
        StartCoroutine(Load("/Screenshot1.jpg"));
        //StartCoroutine(Load("/Screenshot5.jpg"));//此行用于测试
    }

    /// <summary>
    /// 以WWW方式进行加载
    /// </summary>

    IEnumerator Load(string name)
    {
        double startTime = (double)Time.time;
        //请求WWW
        //WWW www = new WWW("file://D:\\test.jpg");
        string path = (Application.dataPath + name);
        WWW www = new WWW("file://" + path);
        Debug.Log(path);
        yield return www;
        if (www != null && string.IsNullOrEmpty(www.error))
        {
            Debug.Log("abc");
            //获取Texture
            Texture2D texture = www.texture;

            //创建Sprite
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            //image.sprite = sprite;
            startTime = (double)Time.time - startTime;
            Debug.Log("WWW加载用时:" + startTime);



            //b为总像素点数，a为红色像素点数
            int b = 0;
            int a = 0;
            //到此已成功转化格式，开始输出像素
            Color[] textureCol = texture.GetPixels();

            for (int i = 0; i < textureCol.Length; i++)
            {


                //Debug.LogError(textureCol[i].r.ToString());
                string str = textureCol[i].r.ToString();
                b = b + 1;
                float num = float.Parse(str);

                string str1 = textureCol[i].g.ToString();
                float num1 = float.Parse(str1);
                string str2 = textureCol[i].b.ToString();
                float num2 = float.Parse(str2);
                 //Debug.Log(num);
                 //Debug.Log(num1);//0.2
                //Debug.Log(num2);//0.2
                if (num > 0.3&&num<0.35 )//&& num1 < num && num2 < num)
                    a++;

            }
            Debug.Log("总像素点数" + b);
            Debug.Log("满足条件的像素点数" + a+" "+name);

            startTime = (double)Time.time - startTime;
            Debug.Log("总用时:" + startTime);

            yield return new WaitForSeconds(1.0f);

        }
    }
}
