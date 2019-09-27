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
        if (position)
        {
            Debug.Log("Position on");
            Vector3 currentPos = transform.position;
            Vector3 parentPos = parent.transform.position;
            parent.transform.position = new Vector3(parentPos.x - currentPos.x + originalPos.x, parentPos.y - currentPos.y + originalPos.y, parentPos.z - currentPos.z + originalPos.z);
        }
        if(rotation)
        {
            Debug.Log("Rotation on");
            Vector3 currentRot = transform.rotation.eulerAngles;
            Vector3 parentRot = parent.transform.rotation.eulerAngles;
            currentRot = new Vector3(currentRot.x, currentRot.y, currentRot.z);
            parent.transform.rotation = Quaternion.Euler(currentRot);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            originalRot = parent.transform.rotation.eulerAngles;
            position = false;
            rotation = true;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            originalPos = transform.position;
            rotation = false;
            position = true;
        }
	}
}
