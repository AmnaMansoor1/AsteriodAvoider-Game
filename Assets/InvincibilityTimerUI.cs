using UnityEngine;
using UnityEngine.UI;

public class InvincibilityTimerUI : MonoBehaviour
{
    public Text timerText;   // drag the UI Text here
    private float remaining = 0f;
    private bool active = false;

    void Update()
    {
        if (active)
        {
            remaining -= Time.deltaTime;
            if (remaining <= 0f)
            {
                active = false;
                timerText.text = "";
            }
            else
            {
                timerText.text = "Invincible: " + remaining.ToString("F1") + "s";
            }
        }
    }

    public void StartTimer(float duration)
    {
        remaining = duration;
        active = true;
    }
}