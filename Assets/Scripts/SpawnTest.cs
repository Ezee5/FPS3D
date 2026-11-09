using UnityEngine;

public class SpawnTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject objectToSpawn; // The Object to spawn
    void Start()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
