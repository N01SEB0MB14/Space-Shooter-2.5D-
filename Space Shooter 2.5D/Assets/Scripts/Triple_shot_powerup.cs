using UnityEngine;

public class Triple_shot_powerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private int powerUpID;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();

        

    }
    void movement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && powerUpID == 1)
            {
                player.tripleShotActive = true;
                Destroy(this.gameObject);
            }
            else if (player != null && powerUpID == 2)
            {
                player.SpeedBoostActive = true;
                Destroy(this.gameObject);
            }
            //else if (player != null && powerUpID == 3)
            //{
            //player.ShieldActive = true;
            //Destroy(this.gameObject);
            //}
        }


    }
}
