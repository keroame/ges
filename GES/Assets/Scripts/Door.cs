using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public GameObject doorObject;               // gameobject to rotate
    public float rotationSpeed = 1.0f;          // opening and closing rotation speed
    public float doorCloseDelaySeconds = 2.0f;  // delay in seconds after player leaves trigger before door starts to close

    private Quaternion originalRotation;        // original rotation of door
    private Quaternion finalRotation;           // rotation value of fully opened door
    private bool doorOpen = false;              // checks if door is supposed to be opened or closed

	void Start () {
        // set original rotation
        originalRotation = doorObject.transform.rotation;

        // set final rotation to 90 anticlockwise of original rotation
        finalRotation = Quaternion.Euler(originalRotation.eulerAngles + new Vector3(0, 0, -90));
	}
	
	void Update () {
        if (doorOpen)       // if door is supposed to be open
        {
            // rotate door object to open state
            doorObject.transform.rotation = Quaternion.Euler(   Vector3.Lerp(doorObject.transform.rotation.eulerAngles, 
                                                                finalRotation.eulerAngles,
                                                                Time.deltaTime * rotationSpeed));
        }                   // if door is supposed to be closed
        else
        {
            // rotate door object back to its original rotation
            doorObject.transform.rotation = Quaternion.Euler(Vector3.Lerp(doorObject.transform.rotation.eulerAngles,
                                                                originalRotation.eulerAngles,
                                                                Time.deltaTime * rotationSpeed));
        }  
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")      // when player enters the door trigger
            doorOpen = true;    // open door
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")      // when player leaves the door trigger
            StartCoroutine(CloseDelay());   // start coroutine
    }

    IEnumerator CloseDelay()
    {
        yield return new WaitForSeconds(doorCloseDelaySeconds);     // wait for close delay
        doorOpen = false;   // close door
    }
}
