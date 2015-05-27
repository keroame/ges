using UnityEngine;
using System.Collections;

public class EndPoint : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")      // if player has entered end point
        {
            Debug.Log("End point reached");     // display text
        }
    }
}
