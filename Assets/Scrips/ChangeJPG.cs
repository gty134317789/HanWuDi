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
        StartCoroutine(Load());
    }

    /// <summary>
    /// 以WWW方式进行加载
    /// </summary>
    private void LoadByWWW()
    {
        StartCoroutine(Load());
        
    }

    IEnumerator Load()
    {
        double startTime = (double)Time.time;
        //请求WWW
        //WWW www = new WWW("file://D:\\test.jpg");
        string path = (Application.dataPath + "//Screenshot.jpg");
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
                if (num > 0.25)
                    a = a + 1;

            }
            Debug.Log("总像素点数" + b);
            Debug.Log("满足条件的像素点数" + a);

            startTime = (double)Time.time - startTime;
            Debug.Log("总用时:" + startTime);

            yield return new WaitForSeconds(1.0f);

        }
    }
}
