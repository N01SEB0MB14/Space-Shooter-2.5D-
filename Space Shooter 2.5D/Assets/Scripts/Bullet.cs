using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.tag = "Laser";

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 7f)
        {
            if(transform.parent != null)
            {
               Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
            

        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

    }
}
