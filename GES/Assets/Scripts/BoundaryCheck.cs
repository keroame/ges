using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoundaryCheck : MonoBehaviour {

    public float secondsBeforeDeath = 3;

    private bool isInBoundary = true;
    private float deathTimer;
    private Text boundaryText;
	
    void Start()
    {
        deathTimer = secondsBeforeDeath;
        boundaryText = GameObject.Find("BoundaryText").GetComponent<Text>();
    }

	void Update () {
	    if (!isInBoundary)
        {
            StartCoroutine(WarnDeath());
        }
	}

    IEnumerator WarnDeath()
    {
        Debug.Log(deathTimer);
        deathTimer -= Time.deltaTime;
        if (deathTimer <= 0)
        {
            Application.LoadLevelAsync(Application.loadedLevel);
        }
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            isInBoundary = true;
            deathTimer = secondsBeforeDeath;
            boundaryText.color = Color.clear;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Boundary")
        {
            isInBoundary = false;
            boundaryText.color = Color.red;
        }
    }
}
