using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "QuizQuestion", fileName = "New Question")]
public class QuizQuestion : ScriptableObject
{
    [SerializeField] string question = "Enter a new question here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswer;

}
