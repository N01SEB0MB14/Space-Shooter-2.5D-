using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float speed = 5f;
    private Animator _anim;
    private CircleCollider2D _circleCollider;
    [SerializeField]
    private GameObject SpawnManager;

    void Start()
    {
 
        
        
            _anim = this.GetComponent<Animator>();
            _circleCollider = this.GetComponent<CircleCollider2D>();
            if (_anim == null)
            {
                Debug.LogError("Animator component not found on the enemy object.");
            }
            else if (_circleCollider == null)
            {
                Debug.LogError("CircleCollider2D component not found on the enemy object.");
            }
            else
            {
                Debug.Log("Animator and CircleCollider2D component found on the enemy object.");
            }
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            _anim.SetTrigger("Collided");
            _circleCollider.enabled = false;
            Destroy(this.gameObject, 2.36f);
            if (SpawnManager != null)
            {
                SpawnManager.GetComponent<SpawnManager>().startSpawn = true;
            }
        }
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && !player.ShieldActive)
            {
                player.takeDamage();
                _anim.SetTrigger("Collided");
                _circleCollider.enabled = false;
                Destroy(this.gameObject, 2.36f);
                if (SpawnManager != null)
                {
                    SpawnManager.GetComponent<SpawnManager>().startSpawn = true;
                }
            }
        }
        
    }
}
