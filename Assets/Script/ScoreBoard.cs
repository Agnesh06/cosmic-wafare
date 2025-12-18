using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score = 0;
    [SerializeField] TMP_Text ScoreBoardText;
    public void InsreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
        ScoreBoardText.text = score.ToString();
    }
}
