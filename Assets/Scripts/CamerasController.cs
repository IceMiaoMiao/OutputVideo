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
		//��Ҫ�Լ� �����һ��cam��Tag�ֱ���Ӹ����������
		foreach (GameObject cam in cameras)
		{
			//ͨ�����������е��������Camera��enable ����Ϊfalse
			Camera theCam = cam.GetComponent<Camera>() as Camera;
			theCam.enabled = false;
		}

		//��Ҫ�л����������Camera����Ϊtrue
		string oneToUse = "Camera" + currentCam;
		Camera usedCam = GameObject.Find(oneToUse).GetComponent<Camera>() as Camera;
		usedCam.enabled = true;
	}
}
