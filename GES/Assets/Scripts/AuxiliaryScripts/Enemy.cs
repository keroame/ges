using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float moveSpeed = 1.0f;      // movement speed of unit in z axis

	void Start () {
        GetComponent<Animator>().SetFloat("Speed", 1.0f);   // Speed requires at least a moveSpeed of 0.5 to trigger move animation
	}

    void Update()
    {
        // Linearly interpolate its position in the z axis in accordance to moveSpeed
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(0, 0, 1), moveSpeed * Time.deltaTime);
    }
}
