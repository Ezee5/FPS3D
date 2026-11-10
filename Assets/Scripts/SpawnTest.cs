using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject objectToSpawn; // The Object to spawn

    public Vector3 spawnPosition; // The position where the object can be spawned
    void Start()
    {
        Instantiate(objectToSpawn, spawnPosition, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
