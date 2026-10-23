using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timerValue;
    [SerializeField] private float timeToCompleteQuestion = 10f;
    [SerializeField] private float timeToShowCorrectAnswer = 5f;
    public float fillFraction = 1f;
    public bool isAnsweringQuestion = false;
    public bool LoadNextQuestion = false;

    private void Start()
    {
        isAnsweringQuestion = true;
        timerValue = timeToCompleteQuestion;
    }

    private void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            fillFraction = timerValue / timeToCompleteQuestion;
            if (timerValue <= 0)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            fillFraction = timerValue / timeToShowCorrectAnswer;
            if (timerValue <= 0)
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                LoadNextQuestion = true;
            }
        }
    }

}
