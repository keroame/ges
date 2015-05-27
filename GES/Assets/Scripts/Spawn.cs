using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject spawnUnit;        // Prefab to spawn
    public bool oneTimeSpawn = false;   // If spawner will only spawn once
    public float spawnDelay = 2;        // Interval between spawn times (seconds)

    void Start()
    {
        if (!oneTimeSpawn)          // If spawner is not a one-time spawner
        {
            InvokeRepeating("SpawnUnit", 0, spawnDelay);     // Calls SpawnUnit() method, repeats every spawnDelay seconds
        }
        else
        {
            SpawnUnit();
        }
    }

    void SpawnUnit()
    {
        // Spawn the prefab at spawner position with spawner's rotation values
        Instantiate(spawnUnit, transform.position, transform.rotation);  
    }

    void OnDrawGizmos()
    {
        // Draws a red cube only in the editor to display spawner location
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + new Vector3(0, 0.5f, 0), transform.localScale);
    }
}
