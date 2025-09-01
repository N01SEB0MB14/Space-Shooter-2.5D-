using System;
using UnityEngine;
using UnityEngine.UI;
public class MyGameCanvas : MonoBehaviour
{
    [SerializeField]
    private Text GameOverText;
    bool flicker;
    private GameObject GameOver;
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
        if (GameOver != null && !flicker&&((Time.time - currentTime) >= 0.5f||currentTime==0))
        {
            GameOver.SetActive(false);
            flicker = true;
            currentTime = Time.time;
            Debug.Log("Flicker");
        }
        else if (GameOver != null && flicker &&(Time.time -currentTime)>=0.5f)
        {
            GameOver.SetActive(true);
            flicker = false;
            Debug.Log("Return");
            currentTime = Time.time;
        }
        else
        {
            Debug.Log(currentTime-Time.time);
        }


        }
    public void ShowGameOver()
    {
        if (GameOverText != null)
        {
            Instantiate(GameOverText, new Vector3(0,0, 0), Quaternion.identity);
            GameOver = GameObject.FindGameObjectWithTag("Game Over");
            GameOver.transform.SetParent(this.transform, true);
            GameOver.transform.position = new Vector3(444.5f, 224.9719f, 0);
        }
    }
}
