using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.tag = "Laser";
        Debug.Log("Bullet created with tag: " + this.tag);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 7f)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

    }
}
