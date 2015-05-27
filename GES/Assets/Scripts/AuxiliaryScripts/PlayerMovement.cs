using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 3;             // movement speed of player
    public float rotationSpeed = 1.0f;      // rotation speed of player
	
	void Update () {
        // rotate the player when player presses Left or Right in accordance with rotation speed
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * 180 * rotationSpeed * Time.deltaTime);

        // move the player when player presses Up or Down in accordance with movement speed
        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
	}
}