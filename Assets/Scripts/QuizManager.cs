using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    
    public Text questionText;
    public Button[] answerButtons;
    public Text scoreText;
    public Text feedbackText; // New Text for feedback
    public GameObject resultPanel; //Tambahkan referensi ke panel hasil

    private List<Question> questions;
    private int currentQuestionIndex;
    private int score;


    private float questionTimeRemaining; // Waktu tersisa untuk pertanyaan saat ini
    private bool isAnswered; // Status apakah pertanyaan sudah dijawab
    public float questionTimeLimit = 10f; // Waktu limit untuk setiap pertanyaan
    public float questionDelay = 1.5f;

    void Start()
    {
        LoadQuestions();
        currentQuestionIndex = 0;
        score = 0;
        ShowQuestion();
    }

    void LoadQuestions()
    {
        questions = new List<Question>
        {
            new Question { questionText = "Apa ciri fisik utama yang membedakan harimau dari kucing besar lainnya?", answers = new List<string> { "Bulu hitam penuh", "Garis-garis pada bulu", "Bulu berbintik", "Ekor pendek" }, correctAnswerIndex = 1 },
            new Question { questionText = "Berapa lama masa kehamilan seekor harimau betina??", answers = new List<string> { "2-3 bulan", "4-5 bulan", "6-7 bulan", "8-9 bulan" }, correctAnswerIndex = 1 },
            new Question { questionText = "Salah satu upaya konservasi utama untuk melindungi harimau adalah:?", answers = new List<string> { "Penangkaran di kebun binatang", "Penyelundupan harimau ke luar negeri", "Penghancuran habitat", "Pendirian taman nasional dan cagar alam" }, correctAnswerIndex = 3 },
            new Question { questionText = "Apa strategi utama harimau dalam berburu mangsa??", answers = new List<string> { "Berburu dalam kelompok besar", "Menunggu mangsa di sarang", "Berburu secara soliter dan mengintai mangsa", "Mengikuti dan mencuri mangsa dari hewan lain" }, correctAnswerIndex = 2 },
            new Question { questionText = "Di mana harimau biasanya tinggal di alam liar???", answers = new List<string> { "Padang rumput", "Gurun pasir", "Hutan tropis dan subtropis", "Daerah kutub" }, correctAnswerIndex = 2 },
        };
    }

    void ShowQuestion()
    {
        Question question = questions[currentQuestionIndex];
        questionText.text = question.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.answers[i];
            int index = i;  // Local copy of loop variable for closure
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index));
        }
    }

    void OnAnswerSelected(int index)

    {
        if (index == questions[currentQuestionIndex].correctAnswerIndex)
        {
            score += 20;


        }

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Count)
        {
            ShowQuestion();
            Invoke("ShowQuestion", questionDelay);
        }
        else
        {
            EndQuiz();
        }
    }

    void EndQuiz()
    {
        questionText.gameObject.SetActive(false);
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }
        scoreText.text = "Score: " + score;
        scoreText.gameObject.SetActive(true);

        // Menampilkan panel hasil dan skor akhir
        resultPanel.SetActive(true);
        resultPanel.GetComponentInChildren<Text>().text = "Final Score: " + score;
    }
}

