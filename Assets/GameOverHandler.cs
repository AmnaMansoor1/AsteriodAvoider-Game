using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public GameObject gameOverDisplay;
    public AsteroidSpawner asteroidSpawner;

    public void EndGame()
    {
        asteroidSpawner.enabled = false;
        gameOverDisplay.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);   // reload the game scene
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);   // load main menu
    }
}