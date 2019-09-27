using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlipper : MonoBehaviour {

    public GameObject parentCam;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("f"))
        {
            Vector3 currentRotation = parentCam.transform.rotation.eulerAngles;
            currentRotation = new Vector3(currentRotation.x, currentRotation.y + 180, currentRotation.z);
            parentCam.transform.rotation = Quaternion.Euler(currentRotation);
        }
    }
}
