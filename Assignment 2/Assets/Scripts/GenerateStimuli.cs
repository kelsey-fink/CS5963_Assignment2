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

    private float wait;
    private float time_waited;
    private bool enabled;
    private bool started;

    // Use this for initialization
    void Start () {
        wait = 2.0f;
        time_waited = 0.0f;
        enabled = true;
        started = false;
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

        if (!enabled && started)
        {
            time_waited += Time.deltaTime;
            redMesh.enabled = false;

            if (time_waited >= wait)
            {
                blueLeftMesh.enabled = false;
                blueRightMesh.enabled = false;
                Debug.Log(time_waited);
                time_waited = 0.0f;
                started = false;
            }
        }
        else if (enabled && started)
        {
            time_waited += Time.deltaTime;
            redMesh.enabled = true;

            while (time_waited >= wait)
            {
                blueLeftMesh.enabled = true;
                blueRightMesh.enabled = true;
                Debug.Log(time_waited);
                time_waited = 0.0f;
                started = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.S))
        {
            if (enabled)
            {
                started = true;
                enabled = false;
            }
            else
            {
                started = true;
                enabled = true;
            }
        }
    }
}
