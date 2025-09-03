using System;
using UnityEngine;
using UnityEngine.UI;
public class MyGameCanvas : MonoBehaviour
{
    [SerializeField]
    private Text GameOverText;
    [SerializeField]
    private Text RestartText;
    bool flicker;
    private GameObject GameOver;
    private GameObject Restart;
    private float currentTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flicker = false;
        currentTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver != null && Restart!=null && !flicker&&((Time.time - currentTime) >= 0.5f||currentTime==0))
        {
            GameOver.SetActive(false);
            Restart.SetActive(false);
            flicker = true;
            currentTime = Time.time;
        }
        else if (GameOver != null && Restart != null && flicker &&(Time.time -currentTime)>=0.5f)
        {
            GameOver.SetActive(true);
            Restart.SetActive(true);
            flicker = false;
            currentTime = Time.time;
        }
        


        }
    public void ShowGameOver()
    {
        if (GameOverText != null)
        {
            Instantiate(GameOverText, new Vector3(0,0, 0), Quaternion.identity);
            Instantiate(RestartText, new Vector3(0, 0, 0), Quaternion.identity);
            GameOver = GameObject.FindGameObjectWithTag("Game Over");
            Restart = GameObject.FindGameObjectWithTag("Restart");
            GameOver.transform.SetParent(this.transform, true);
            Restart.transform.SetParent(this.transform, true);
            GameOver.transform.position = new Vector3(444.5f, 264.9719f, 0);
            Restart.transform.position = new Vector3(444.5f, 224.9719f, 0);
        }
    }
}
