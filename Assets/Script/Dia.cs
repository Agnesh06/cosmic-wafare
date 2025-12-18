using UnityEngine;
using TMPro;

public class Dia : MonoBehaviour
{

    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;
    int currentLine = 0;
    void Start()
    {
        dialogueText.text = timelineTextLines[currentLine];
    }

    public void NextDialogueLine()
    {
        currentLine++;
        if (currentLine < timelineTextLines.Length)
        {
            dialogueText.text = timelineTextLines[currentLine];
        }
        else
        {
            Debug.Log("Dialogue finished.");
        }
    }
}
