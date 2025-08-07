using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private GameObject _laserPrefab;
    private float lastFireTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //current pos=new pos(0,0,0);
        transform.position = new Vector3(0, 0, 0);
        lastFireTime = 0;



    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();
        fireLaser(lastFireTime);
    }
        void calculateMovement()
        {
            if (transform.position.x >= 12)
            {
                float y = transform.position.y;
                // Player shows up on opposite side if it goes off-screen
                transform.position = new Vector3(-12, y, 0);
            }
            else if (transform.position.x <= -12)
            {
                float y = transform.position.y;
                transform.position = new Vector3(12, y, 0);
            }
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.8f, 0), 0);
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        }
        //spawn laser if fire key used
        void fireLaser(float time = 0)
        {
            if (Input.GetKey(KeyCode.Space) && ((time == 0) || (Input.GetKey(KeyCode.Space) && (Time.time - time) >= 0.25f)))
            {
                Instantiate(_laserPrefab, new Vector3(transform.position.x,(transform.position.y+1f),transform.position.z), Quaternion.identity);
                lastFireTime = Time.time;
            }
        }
    }

