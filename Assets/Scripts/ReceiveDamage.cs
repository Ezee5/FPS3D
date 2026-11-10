using UnityEngine;

public class Rec : MonoBehaviour
{

    public int health = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("projectile"))
        {
            // Handle damage logic
            Debug.Log("Received damage from projectile");
            // Destroy projectile logic
            Destroy(collision.gameObject);

            health -= 10; // Example: reduce health by 10
            Debug.Log("Current Health: " + health);

            if (health = 0)
            {
                Debug.Log("Player is dead")
            }
        }
    }
}
