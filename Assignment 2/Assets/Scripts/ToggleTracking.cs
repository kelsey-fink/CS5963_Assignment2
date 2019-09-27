using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTracking : MonoBehaviour {

    public GameObject parent;
    private Vector3 originalPos;
    private bool position = false;
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

		if (Input.GetKeyDown(KeyCode.R))
        {

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            originalPos = transform.position;
            position = true;
        }
	}
}
