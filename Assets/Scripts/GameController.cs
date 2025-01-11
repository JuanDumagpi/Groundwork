using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerHP.OnPlayerDied += GameOverScreen;
    }

    void GameOverScreen()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

}
