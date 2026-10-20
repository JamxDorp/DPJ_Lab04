using TMPro;
using UnityEngine;
using static UnityEngine.InputSystem.HID.HID;

public class Questionaire : MonoBehaviour
{
    [SerializeField] private QuestionSO[] questionSO;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private int currentQuestionIndex = 0;
    [SerializeField] private GameObject[] answerButtons;

    private void Start()
    {
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        questionText.text = questionSO[currentQuestionIndex].GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questionSO[currentQuestionIndex].GetAnswer(i);
        }
    }
    private void OnAnswerSelected(int index)
    {
        
    }
}
