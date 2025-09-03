using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _Triple_shot;
    [SerializeField]
    private GameObject _ShieldPrefab;
    [SerializeField]
    private GameObject UImanager;
    [SerializeField]
    private GameObject MyGameCanvas;

    public int _score { get; set; }
    public bool tripleShotActive { get; set; }
    public bool SpeedBoostActive { get; set; }
    public bool ShieldActive { get; set; }
    public float Shieldinit { get; set; }
    private bool SpeedBoostInitActive;
    public float SpeedBoostInit { get; set; }
    private float lastFireTime;
    private bool spawnshield;
    public float tripleShotInit { get; set; }
    private bool tripleShotInitActive;
    public int health { get; set; } = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.tag = "Player";
        this._score = 0;
        //current pos=new pos(0,0,0);
        transform.position = new Vector3(0, 0, 0);
        lastFireTime = 0;
        tripleShotActive = false;
        tripleShotInitActive = false;
        spawnshield = false;
        speed = 5f;



    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();
        fireLaser(lastFireTime,tripleShotInit,tripleShotActive,tripleShotInitActive);
        shield();
    }
    void shield()
    {
        if(ShieldActive&& !spawnshield)
        {
            spawnshield = true;
            Instantiate(_ShieldPrefab, transform.position, Quaternion.identity);
        }
        else if (ShieldActive && (Time.time - Shieldinit) >= 5f)
        {
            ShieldActive = false;
            spawnshield = false;
            Destroy(GameObject.FindGameObjectWithTag("Shield"));
        }

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
            if (SpeedBoostActive && !SpeedBoostInitActive)
            {
                speed = 10f;
                SpeedBoostInitActive = true;
            }
            else if (SpeedBoostActive && (Time.time - SpeedBoostInit) >= 5f)
            {
                speed = 5f;
                SpeedBoostActive = false;
                SpeedBoostInitActive = false;
            }
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        }
    //spawn laser if fire key used
    void fireLaser(float time = 0,float tripletime=0,bool triple=false,bool tripleInit=false)
    {
        if (Input.GetKey(KeyCode.Space) && ((time == 0) || (Input.GetKey(KeyCode.Space) && (Time.time - time) >= 0.25f)))
        {
            if (triple && !tripleInit)
            {
                Instantiate(_Triple_shot, new Vector3((transform.position.x+1f), transform.position.y, transform.position.z), Quaternion.identity);
                tripleShotInitActive = true;
                lastFireTime = Time.time;
            }
            else if (triple && (Time.time - tripletime) <= 5f && (Time.time - time) >= 0.25f)
            {
                Instantiate(_Triple_shot, new Vector3((transform.position.x + 1f), transform.position.y, transform.position.z), Quaternion.identity);
                lastFireTime = Time.time;
            }
            else
            {

                Instantiate(_laserPrefab, new Vector3(transform.position.x, (transform.position.y + 1f), transform.position.z), Quaternion.identity);
                lastFireTime = Time.time;
            }
            if (triple && (Time.time - tripletime) >= 5f)
            {
                Debug.Log(Time.time-tripletime);
                tripleShotActive = false;
                tripleShotInitActive = false;
            }
        }
    }
    public void takeDamage()
    {
        this.health--;
        if (this.health <= 0)
        {
            MyGameCanvas.GetComponent<MyGameCanvas>().ShowGameOver();
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
            Debug.Log("Player destroyed");

        }
        else
        {
            Debug.Log("Player health: " + this.health);
        }
        UImanager.GetComponent<UIManager>().updateLives(this.health);
    }
    }

