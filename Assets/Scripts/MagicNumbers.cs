using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicNumbers : MonoBehaviour
{

    public int Min = 1;
    public int Max = 1000;
    private int _guess;
    void Start()
    {
        Debug.Log("Hello");
        Debug.Log($"Загодай число от {Min} до {Max}");
        CalculateGuess();
        AskAboutGuess();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Max = _guess;
            CalculateGuess();
            AskAboutGuess();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Min = _guess;
            CalculateGuess();
            AskAboutGuess();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Угадал твое чилсо {_guess}");
        }
    }
    
    private void AskAboutGuess()
    {
        Debug.Log($"Твоё число {_guess}?");
    }

    private void CalculateGuess()
    {
        _guess = (Min + Max) / 2;
    }
}
