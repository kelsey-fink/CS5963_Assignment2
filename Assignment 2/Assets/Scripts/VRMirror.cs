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
        if (isMatch)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            rotationDiff = 180 - currentRotation.y;
            Vector3 mirrorRotation = currentRotation;
            mirrorRotation = new Vector3(currentRotation.x, currentRotation.y, currentRotation.z); //currentRotation.y + rotationDiff
            cube.transform.rotation = Quaternion.Euler(mirrorRotation);

            Vector3 currentPosition = transform.position;
            Vector3 mirrorPosition = currentPosition;
            mirrorPosition = new Vector3(currentPosition.x * 1, currentPosition.y, currentPosition.z + 3);
            cube.transform.position = mirrorPosition;
          
            Debug.Log("match");
        }
        if (isMirror)
        {
            Vector3 currentRotation = transform.rotation.eulerAngles;
            rotationDiff = 180 - currentRotation.y;
            Vector3 matchRotation = currentRotation;
            matchRotation = new Vector3(currentRotation.x, rotationDiff, currentRotation.z * -1);
            cube.transform.rotation = Quaternion.Euler(matchRotation);

            Vector3 currentPosition = transform.position;
            Vector3 matchPosition = currentPosition;
            matchPosition = new Vector3(currentPosition.x, currentPosition.y, 3 - currentPosition.z);
            cube.transform.position = matchPosition;

            Debug.Log("mirror");
        }
    }
}
