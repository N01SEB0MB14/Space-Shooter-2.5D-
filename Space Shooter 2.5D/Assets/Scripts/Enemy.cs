using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Sprite[] LiveSprites;
    private Image _liveImage;
    private Animator _anim;
    private BoxCollider2D _boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            Debug.LogError("Player object not found in the scene. Make sure the Player has the 'Player' tag assigned.");
        }
        else
        {
            transform.position = new Vector3(0, 5, 0); // Set initial position of the enemy
            _anim = this.GetComponent<Animator>();
            _boxCollider = this.GetComponent<BoxCollider2D>();
            if (_anim == null)
            {
                Debug.LogError("Animator component not found on the enemy object.");
            }else if(_boxCollider == null)
            {
                Debug.LogError("BoxCollider2D component not found on the enemy object.");
            }
            else {
                Debug.Log("Animator and BoxCollider2D component found on the enemy object.");
            }
        }

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
                _anim.SetTrigger("Enemy death");
                _boxCollider.enabled = false;
                Destroy(gameObject,2.4f);
                player._score += 10; // Increase score
                player.takeDamage();// Assuming takeDamage method exists in Player script
         
            }
            else if (player != null && player.ShieldActive)
            {
                // Handle collision with player when shield is active
                Debug.Log("Enemy collided with Player but shield is active!");
                _anim.SetTrigger("Enemy death");
                _boxCollider.enabled = false;
                Destroy(gameObject, 2.4f); // Destroy the enemy
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
            _anim.SetTrigger("Enemy death");
            _boxCollider.enabled = false;
            Destroy(gameObject,2.4f); // Destroy the enemy
            Player.GetComponent<Player>()._score += 10; // Increase score
        }
    }
}
