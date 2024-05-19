using UnityEngine;
using TMPro;

public class NPCTextController : MonoBehaviour
{
    public TextMeshProUGUI npcText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        // Set initial text if needed
        npcText.text = Time.time.ToString();
    }

    public void UpdateText(string newText)
    {
        npcText.text = newText;
    }
}
