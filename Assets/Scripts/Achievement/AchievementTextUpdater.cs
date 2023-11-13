using Achievement;
using UnityEngine;
using UnityEngine.UI;

public class AchievementTextUpdater : MonoBehaviour
{
    public Text achievementText;

    public void UpdateAchievementText(string newText)
    {
        if (achievementText != null)
        {
            achievementText.text = newText;
        }
        else
        {
            Debug.LogWarning("UI Text element is not assigned. Please assign it in the editor.");
        }
    }
}