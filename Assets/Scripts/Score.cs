using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText;
    private float _currentScore;
    private  const string HighscoreKey = "Highscore";
    void Update()
    {
        _currentScore += Time.deltaTime;
        scoreText.text = Mathf.RoundToInt(_currentScore).ToString();
    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighscoreKey, 0);
        if (_currentScore > currentHighScore)
        {
            PlayerPrefs.SetInt(HighscoreKey, Mathf.RoundToInt(_currentScore));
        }
    }
}
