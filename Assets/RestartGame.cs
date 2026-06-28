using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Asteroids");
    }
}