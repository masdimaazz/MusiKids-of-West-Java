using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    public Text finalScoreText;

    void Start()
    {
        finalScoreText.text = "Your final score: " + PlayerPrefs.GetInt("FinalScore");
    }

    public void RestartQuiz()
    {
        SceneManager.LoadScene("QuizScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
