using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Scriptable Objects/New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] private string question;
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex;
    
    public string GetQuestion() => question;
    public int GetCorrectAnswerIndex() => correctAnswerIndex;
    public string GetAnswer(int index) => answers[index];

}
