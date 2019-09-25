using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMirror : MonoBehaviour {

    bool isMirror = false;
    bool isMatch = false;
    public GameObject cube;
    float rotationDiff = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("m"))
        {
            if(isMirror == false)
            {
                isMirror = true;
                isMatch = false;
            }
            else
            {
                isMatch = true;
                isMirror = false;
            }
        }
        if(isMirror)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            rotationDiff = 180 - currentRotation.y;
            Vector3 mirrorRotation = currentRotation;
            mirrorRotation = new Vector3(currentRotation.x * -1, currentRotation.y + rotationDiff, currentRotation.z);
            cube.transform.rotation = Quaternion.Euler(currentRotation);
            Debug.Log("mirror");
        }
        if(isMatch)
        {
            Debug.Log("match");
        }
    }
}
