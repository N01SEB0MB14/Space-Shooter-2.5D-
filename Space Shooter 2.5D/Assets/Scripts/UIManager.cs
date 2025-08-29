using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null && Player != null)

            scoreText.text = $"Score: {Player.GetComponent<Player>()._score}";

    }
}
