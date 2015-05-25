using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject spawnUnit;        // Prefab to spawn
    public float spawnDelay = 2;        // Interval between spawn times (seconds)

    void Start()
    {
        InvokeRepeating("SpawnUnit", 0, spawnDelay);     // Calls SpawnUnit() method, repeats every spawnDelay seconds
    }

    void SpawnUnit()
    {
        // Spawn the prefab at spawner position with default rotation values
        Instantiate(spawnUnit, transform.position, Quaternion.identity);  
    }

    void OnDrawGizmos()
    {
        // Draws a red cube only in the editor to display spawner location
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + new Vector3(0, 0.5f, 0), Vector3.one);
    }
}
