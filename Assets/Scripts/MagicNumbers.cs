using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicNumbers : MonoBehaviour
{

    private int _min;
    private int _max;
    private int _guess;
    void Start()
    {
        Debug.Log("Hello");
        _min = 1;
        _max = 1000;
        Debug.Log($"Загодай число от {_min} до {_max}");
        CalculateGuess();
        Debug.Log($"Твоё число {_guess}");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _max = _guess;
            CalculateGuess();
            Debug.Log($"Твоё число {_guess}");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _min = _guess;
            CalculateGuess();
            Debug.Log($"Твоё число {_guess}");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Угадал твое чилсо {_guess}");
        }
    }

    private void CalculateGuess()
    {
        _guess = (_min + _max) / 2;
    }
}
