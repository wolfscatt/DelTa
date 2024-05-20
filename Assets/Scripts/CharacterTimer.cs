using UnityEngine;
using TMPro;

public class CharacterTimer : MonoBehaviour
{
    public float initialTime = 86400f; // Set the initial time for each character in seconds (default to 1 day)
    private float remainingTime;
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        remainingTime = initialTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= 2*Time.deltaTime; // Decrease time by the elapsed time since the last frame
            if (remainingTime < 0) remainingTime = 0; // Ensure it doesn't go negative
            UpdateTimerText();
        }
    }


    void UpdateTimerText()
    {
        int days = Mathf.FloorToInt(remainingTime / 86400); // Calculate days (86400 seconds in a day)
        int hours = Mathf.FloorToInt((remainingTime % 86400) / 3600); // Calculate hours (3600 seconds in an hour)
        int minutes = Mathf.FloorToInt((remainingTime % 3600) / 60); // Calculate minutes
        int seconds = Mathf.FloorToInt(remainingTime % 60); // Calculate seconds

        // Format the string to show days, hours, minutes, and seconds
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds);
    }

    // Method to add additional time to the remaining time
    public void AddTime(float additionalTime)
    {
        remainingTime += additionalTime;
    }

}
