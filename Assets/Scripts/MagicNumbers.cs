using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    public int Max = 1000;
    public int Min = 1;
    public TMP_Text RulesFirstGame;
    public TMP_Text TextGame;
    private int _guess;
    private bool _isWin;
    private int _numberOfAttempts;
    private readonly float maxTime = 5;
    private float timer;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        RulesFirstGame.text =
            $"Загадай число от {Min} до {Max}. Нажмите стрелку вверх, если ваше число больше. Нажмите стрелку вниз, если ваше число меньше. Нажмите пробел, если я угадал.";
        CalculateGuess();
        _numberOfAttempts = 1;
        AskAboutGuess();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !_isWin)
        {
            Max = _guess;
            CalculateGuess();
            AskAboutGuess();
            _numberOfAttempts++;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !_isWin)
        {
            Min = _guess;
            CalculateGuess();
            AskAboutGuess();
            _numberOfAttempts++;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_isWin)
        {
            TextGame.text =
                $"Угадал твое чилсо {_guess}. Попыток - {_numberOfAttempts}. Через {maxTime} секунд игра перезапустится";
            _isWin = true;
        }

        if (_isWin)
        {
            timer += Time.deltaTime;

            if (timer > maxTime)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    #endregion

    #region Private methods

    private void AskAboutGuess()
    {
        TextGame.text = $"Твоё число {_guess}?";
    }

    private void CalculateGuess()
    {
        _guess = (Min + Max) / 2;
    }

    #endregion
}