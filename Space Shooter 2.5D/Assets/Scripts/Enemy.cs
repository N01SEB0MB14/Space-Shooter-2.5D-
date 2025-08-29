using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(0, 5, 0); // Set initial position of the enemy

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6)
        {
            // Reset enemy position to the top of the screen
            transform.position = new Vector3(Random.Range(-10f, 10f), 6, 0);
        }
        transform.Translate(Vector3.down * 4 * Time.deltaTime);


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null && !player.ShieldActive)
            {
                // Handle collision with player
                Debug.Log("Enemy collided with Player!");
                Destroy(gameObject);
                player._score += 10; // Increase score
                player.takeDamage(); // Assuming takeDamage method exists in Player script
            }
            else if (player != null && player.ShieldActive)
            {
                // Handle collision with player when shield is active
                Debug.Log("Enemy collided with Player but shield is active!");
                Destroy(gameObject); // Destroy the enemy
                player._score += 10; // Increase score
                player.ShieldActive = false; // Deactivate shield
                Destroy(GameObject.FindGameObjectWithTag("Shield"));
            }
            

        }
        else if (other.gameObject.CompareTag("Laser"))
        {
            // Handle collision with laser
            Debug.Log("Enemy hit by Laser!");
            Destroy(other.gameObject); // Destroy the laser
            Destroy(gameObject); // Destroy the enemy
            Player.GetComponent<Player>()._score += 10; // Increase score
        }
    }
}
