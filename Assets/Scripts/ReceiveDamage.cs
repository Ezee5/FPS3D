using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Rec : MonoBehaviour
{

    public TextMeshProUGUI healthText;

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
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Handle damage logic
            Debug.Log("Received damage from projectile");
            // Destroy projectile logic
            Destroy(collision.gameObject);

            health -= 20; // Example: reduce health by 20
            healthText.text = health.ToString(); // Update Health Text with the current health
            Debug.Log("Current Health: " + health);

            if (health <= 0)
            {
                Debug.Log("Player is dead");
                Destroy(gameObject);
            }
        }
    }
}
