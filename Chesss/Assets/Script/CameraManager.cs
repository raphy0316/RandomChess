using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
	GameObject mainCamera;
	GameObject subCamera;
	// Use this for initialization
	void Start () { 
		mainCamera = GameObject.FindWithTag ("MainCamera");
		subCamera = GameObject.FindWithTag ("SubCamera");
		mainCameraOn();
	}
	void Update(){
		if (!BoardManager.Instance.isBlackTurn) {
			Invoke ("subCameraOn", 0.5f);
		} else {
			Invoke ("mainCameraOn", 0.5f);
		}
	}
	public void mainCameraOn(){
		mainCamera.GetComponent<Camera>().depth = 1;
		subCamera.GetComponent<Camera>().depth = 0;
	}
	public void subCameraOn(){
		mainCamera.GetComponent<Camera>().depth = 0;
		subCamera.GetComponent<Camera>().depth = 1;
	}
	

}
