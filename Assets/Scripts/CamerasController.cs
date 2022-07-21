using UnityEngine;
using System.Collections;

public class CamerasController : MonoBehaviour
{
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			print("camera1");
			cameraSwitch(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			print("camera2");
			cameraSwitch(2);
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			print("camera3");
			cameraSwitch(3);
		}
	}

	void cameraSwitch(int currentCam)
	{
		GameObject[] cameras = GameObject.FindGameObjectsWithTag("cam");
		//需要自己 先添加一个cam的Tag分别添加给各个摄像机
		foreach (GameObject cam in cameras)
		{
			//通过遍历把所有的摄像机的Camera的enable 设置为false
			Camera theCam = cam.GetComponent<Camera>() as Camera;
			theCam.enabled = false;
		}

		//把要切换到的摄像机Camera设置为true
		string oneToUse = "Camera" + currentCam;
		Camera usedCam = GameObject.Find(oneToUse).GetComponent<Camera>() as Camera;
		usedCam.enabled = true;
	}
}
