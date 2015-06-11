using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public enum SpawnerType
    {
        Player,
        Enemy
    }

    public SpawnerType spawnerType = SpawnerType.Enemy;     // Type of spawner
    public GameObject spawnUnit;                            // Prefab to spawn
    public float maxSpawns = 1;                             // Maximum number of spawns
    public float spawnDelay = 2;                            // Interval between spawn times (seconds)

    private float spawnCount = 0;                           // Number of units already spawned

    void Awake()                                            // Player spawns before enemies
    {
        if (spawnerType == SpawnerType.Player)              // if spawner is spawning player
        {
            StartCoroutine(SpawnUnit());                    // spawn player
        }
    }

    void Start()                                            // enemy spawns after player
    {
        if (spawnerType == SpawnerType.Enemy)               // if spawner is spawning enemy
        {
            StartCoroutine(SpawnUnit());                    // spawn enemy
        }
    }

    IEnumerator SpawnUnit()
    {
        while (spawnCount < maxSpawns)                      // check if already reached max no. of spawns
        {
            if (spawnerType == SpawnerType.Enemy)           // if player is enemy
            {
                if (Camera.main != null)                    // check if there is a main camera
                {
                    if (!InCameraView())                    // if spawner is outside camera view
                    {
                        // Spawn the prefab at spawner position with spawner's rotation values
                        Instantiate(spawnUnit, transform.position, transform.rotation);
                        spawnCount++;                        // increment number of spawned units
                        yield return new WaitForSeconds(spawnDelay);    // wait for spawnDelay seconds before continuing spawn function
                    }
                }
            }
            else
            {
                // Spawn the prefab at spawner position with spawner's rotation values
                Instantiate(spawnUnit, transform.position, transform.rotation);
                spawnCount++;       // increment number of spawned units
            }
            yield return null;
        }    
    }

    private bool InCameraView()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);           // return main camera's six planes
        if (GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider>().bounds))    // check if spawner is within the bounds of the six planes
            return true;
        else
            return false;
    }

    void OnDrawGizmos()
    {
        // Draws a red cube only in the editor to display spawner location
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position + new Vector3(0, 0.5f, 0), transform.localScale);
    }
}
