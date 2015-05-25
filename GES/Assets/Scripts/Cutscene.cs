using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cutscene : MonoBehaviour {

    public float cameraSwitchInterval = 5;      // time in seconds before camera switches
    public List<GameObject> cameras;            // List of camera GameObjects

    void Start()
    {
        InitialiseCameras();                    // disables all cutscene cameras
    }

    // called when play button is pressed
    public void StartCutscene()
    {
        StartCoroutine(RunCutscene());          // start the RunCutscene coroutine
    }

    // called when stop button is pressed
    public void StopCutscene()
    {
        StopCoroutine(RunCutscene());           // stops the RunCutscene coroutine
        InitialiseCameras();                    // disables all cutscene cameras
    }

    IEnumerator RunCutscene()
    {
        for (int i = 0; i < cameras.Count; i++)     // for each cutscene camera
        {
            cameras[i].SetActive(true);             // enable current cutscene camera
            yield return new WaitForSeconds(cameraSwitchInterval);  // wait for camera switch interval before continuing with coroutine
            cameras[i].SetActive(false);            // disable current cutscene camera
        }
    }

    void InitialiseCameras()
    {
        foreach (GameObject camera in cameras)
        {
            camera.SetActive(false);
        }
    }

}
