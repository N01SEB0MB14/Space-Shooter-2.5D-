using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private Image livesImage;
    [SerializeField]
    private Sprite[] livesSprites;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        livesImage.sprite = livesSprites[3];



    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null && Player != null)

            scoreText.text = $"Score: {Player.GetComponent<Player>()._score}";

    }
    public void updateLives(int lives)
        {
            if (livesImage != null && livesSprites[lives]!=null)
            {
                livesImage.sprite = livesSprites[lives];
        }
    }
    
}
