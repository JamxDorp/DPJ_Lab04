using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Questionaire : MonoBehaviour
{
    [SerializeField] private QuestionSO[] questionSO;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private int currentQuestionIndex = 0;
    [SerializeField] private GameObject[] answerButtons;
    [SerializeField] private Image timerImage;

    private Timer timer;
    private int correctAnswerIndex = -1;
    private string correctAnswer = "";
    private bool hasAnsweredEarly = false;

    private void Start()
    {
        timer = FindFirstObjectByType<Timer>();
        DisplayQuestion();
    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;

        if (timer.LoadNextQuestion)
        {
            GetNextQuestion();
            timer.LoadNextQuestion = false;
            hasAnsweredEarly = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    private void DisplayQuestion()
    {
        LoadQuestion();
    }

    private void GetNextQuestion()
    {
        currentQuestionIndex++;

        if (currentQuestionIndex < questionSO.Length)
        {
            DisplayQuestion();
            SetButtonState(true);
        }
        else
        {
            questionText.text = "Você completou o questionário!";
            SetButtonState(false);
        }
    }

    private void LoadQuestion()
    {
        correctAnswerIndex = questionSO[currentQuestionIndex].GetCorrectAnswerIndex();
        questionText.text = questionSO[currentQuestionIndex].GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {   
            if (i == correctAnswerIndex)
            {
                correctAnswer = questionSO[currentQuestionIndex].GetAnswer(correctAnswerIndex);;
            }
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionSO[currentQuestionIndex].GetAnswer(i);
        }
    }
    
    private void SetButtonState(bool state)
    {
      for (int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
    private void DisplayAnswer(int index)
    {
        if (index == correctAnswerIndex)
        {
            questionText.text = "Correto!";
        }
        else
        {
            questionText.text = "Desculpa, mas a resposta correta era: " + correctAnswer;
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }
}
