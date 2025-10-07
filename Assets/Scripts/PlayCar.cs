using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCar : MonoBehaviour
{
    public TMP_Text highscoreText;

    void Start()
    {
        highscoreText.text = $"HighScore: {PlayerPrefs.GetInt("Highscore", 0).ToString()}";
    }

    public void PlayCarGame()
    { 
        SceneManager.LoadScene(2);
    }
}
