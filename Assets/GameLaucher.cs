using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLauncher : MonoBehaviour
{
    public Text scoreDisplayText;   // Drag the Text that shows the score
    public Button restartButton;
    public Button startMenuButton;
    public Button continueButton;   // optional

    void Start()
    {
        // Load the saved score from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        if (scoreDisplayText != null)
            scoreDisplayText.text = "Your Score: " + finalScore;

        // Wire up buttons
        if (restartButton != null)
            restartButton.onClick.AddListener(() => SceneManager.LoadScene(1)); // game scene index
        if (startMenuButton != null)
            startMenuButton.onClick.AddListener(() => SceneManager.LoadScene(0)); // menu scene index
        if (continueButton != null)
            continueButton.onClick.AddListener(() => SceneManager.LoadScene(1)); // make continue restart (or remove)
    }
}
