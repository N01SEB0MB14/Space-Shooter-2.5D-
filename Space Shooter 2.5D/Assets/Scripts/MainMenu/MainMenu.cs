using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    bool loadedGame = false;
    float startTime;
    [SerializeField] 
    GameObject mainMenuUI;
    [SerializeField]
    GameObject button;
    public static MainMenu Instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Instance = this;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadedGame && (Time.unscaledTime - startTime >= 0.5f))
        {
            Time.timeScale = 1;
            loadedGame = false;
            Destroy(gameObject);

        }

    }
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 0;
        startTime = Time.unscaledTime;
        loadedGame = true;
        if (mainMenuUI != null && button != null)
        {
            Destroy(mainMenuUI);
            Destroy(button);
        }
    }
}
