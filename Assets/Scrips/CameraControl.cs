using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

	public GameObject close1;
	public GameObject close2;
	public GameObject open1;


    void Start() 
	{
        close1.SetActive(false);
        close2.SetActive(false);
        open1.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState= CursorLockMode.Confined;
    }
}