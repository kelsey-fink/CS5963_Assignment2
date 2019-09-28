using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStimuli : MonoBehaviour {
    public GameObject redSphere;
    private MeshRenderer redMesh;
    public GameObject blueLeftSphere;
    private MeshRenderer blueLeftMesh;
    public GameObject blueRightSphere;
    private MeshRenderer blueRightMesh;

    private float startBlueLeftDist;
    private float startBlueRightDist;
    private float startRedDist;

    private bool enabled = true;
    // Use this for initialization
    void Start () {
        redMesh = redSphere.GetComponent<MeshRenderer>();
        blueLeftMesh = blueLeftSphere.GetComponent<MeshRenderer>();
        blueRightMesh = blueRightSphere.GetComponent<MeshRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        startRedDist = Vector3.Distance(transform.position, redSphere.transform.position);
        startBlueLeftDist = Vector3.Distance(transform.position, blueLeftSphere.transform.position);
        startBlueRightDist = Vector3.Distance(transform.position, blueRightSphere.transform.position);
        Vector3 redSize = redSphere.transform.localScale;
        //Debug.Log("red size: " + redSize);

        blueLeftSphere.transform.localScale = redSize * (startBlueLeftDist / startRedDist);
        //Debug.Log("blue size left: " + (float)blueLeftSphere.transform.localScale.x + ", " + (float)blueLeftSphere.transform.localScale.y + ", " + (float)blueLeftSphere.transform.localScale.z);

        blueRightSphere.transform.localScale = redSize * (startBlueRightDist / startRedDist);
       // Debug.Log("blue size right: " + (float)blueRightSphere.transform.localScale.x + ", " + (float)blueRightSphere.transform.localScale.y + ", " + (float)blueRightSphere.transform.localScale.z);


        if (Input.GetKeyDown(KeyCode.S))
        {
            if(enabled)
            {
                redMesh.enabled = false;

                float wait = 2.0f;
                float time_waited = 0.0f;

                while (time_waited < wait)
                {
                    time_waited += Time.deltaTime;
                    Debug.Log(time_waited);
                }

                blueLeftMesh.enabled = false;
                blueRightMesh.enabled = false;
                enabled = false;
            }
            else
            {
                enabled = true;
                redMesh.enabled = true;

                float wait = 2.0f;
                float time_waited = 0.0f;

                while (time_waited < wait)
                {
                    time_waited += Time.deltaTime;
                }

                blueLeftMesh.enabled = true;
                blueRightMesh.enabled = true;
            }
        }
    }
}
