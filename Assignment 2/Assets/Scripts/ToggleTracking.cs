using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracking : MonoBehaviour {

    public GameObject parent;
    private Vector3 originalPos;
    private Vector3 originalRot;
    private bool position = false;
    private bool rotation = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (rotation)
        {
            Debug.Log("Rotation on");
            Vector3 currentRot = transform.rotation.eulerAngles;
            Vector3 parentRot = parent.transform.rotation.eulerAngles;
            //currentRot = new Vector3(currentRot.x - originalRot.x, currentRot.y - originalRot.y, currentRot.z - originalRot.z);

            //Debug.Log("Before: \n");
            //Debug.Log("Parent: " + parentRot);
            //Debug.Log("Original: " + originalRot);
            //Debug.Log("Current: " + currentRot);
            parent.transform.RotateAround(originalPos, new Vector3(1, 0, 0), (currentRot.x - originalRot.x));
            parent.transform.RotateAround(originalPos, new Vector3(0, 1, 0), -(currentRot.y - originalRot.y));
            parent.transform.RotateAround(originalPos, new Vector3(0, 0, 1), (currentRot.z - originalRot.z));

            parentRot = parent.transform.rotation.eulerAngles;
            //Debug.Log("After: \n");
            //Debug.Log("Parent: " + parentRot);
            //Quaternion.Euler(currentRot));

            originalRot = transform.rotation.eulerAngles;
            originalPos = transform.position;
        }
        if (position)
        {
            Debug.Log("Position on");
            Vector3 currentPos = transform.position;
            Vector3 parentPos = parent.transform.position;
            parent.transform.position = new Vector3(parentPos.x - currentPos.x + originalPos.x, parentPos.y - currentPos.y + originalPos.y, parentPos.z - currentPos.z + originalPos.z);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if(rotation)
            {
                rotation = false;
            }
            else
            {
                position = false;
                rotation = true;
            }
            originalPos = transform.position;
            originalRot = transform.rotation.eulerAngles;

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(position)
            {
                position = false;
            }
            else
            {
                rotation = false;
                position = true;
            }
            originalPos = transform.position;
        }
    }
}
