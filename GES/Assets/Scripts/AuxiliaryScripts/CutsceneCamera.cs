using UnityEngine;
using System.Collections;

public class CutsceneCamera : MonoBehaviour {

    public Vector3 movement;
    public Vector3 rotation;

    void Update()
    {
        // moves the camera by set position every update frame
        transform.position = Vector3.Lerp(transform.position, transform.position + movement, Time.deltaTime);

        // rotates the camera by set position every update frame
        transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, transform.rotation.eulerAngles + rotation, Time.deltaTime));
    }
}
