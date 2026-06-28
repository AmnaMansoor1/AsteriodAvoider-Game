using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.Burst.Intrinsics.X86;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour
{
    private bool isInvincible = false;
    private float invincibleTimer = 0f;

    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0f)
            {
                isInvincible = false;
                // Optional: notify UI that invincibility ended
            }
        }
    }
    public void ActivateInvincibility(float duration)
    {
        isInvincible = true;
        invincibleTimer = duration;
        // Update UI text (see Step 6)
        InvincibilityTimerUI timerUI = FindObjectOfType<InvincibilityTimerUI>();
        if (timerUI != null) timerUI.StartTimer(duration);
    }

    public void crash()
    {
        if (isInvincible) return;   // ignore damage
        gameObject.SetActive(false);
        //// Find the ScoreManager and save the final score
        //ScoreManager sm = FindObjectOfType<ScoreManager>();
        //if (sm != null)
        //    sm.SaveScoreAndEnd();
        //SceneManager.LoadScene("GameLauncher");
        GameOverHandler handler = FindObjectOfType<GameOverHandler>();
        if (handler != null) handler.EndGame();
    }
}
