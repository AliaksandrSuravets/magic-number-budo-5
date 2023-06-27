using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummNumbers : MonoBehaviour
{
    #region Variables

    public TMP_Text TextGame;
    private bool _isWin;
    private int _numberOfAttempts;
    private int _summ;

    #endregion

    #region Unity lifecycle

    // Start is called before the first frame update
    private void Start()
    {
        _summ = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_isWin)
        {
            for (int number = 1; number <= 9; number++)
            {
                if (Input.GetKeyDown(number.ToString()))
                {
                    _summ += number;
                    TextGame.text = $"Сумма:{_summ}";
                    if (_summ >= 50)
                    {
                        _isWin = true;
                    }

                    _numberOfAttempts++;
                }
            }
        }
        else
        {
            TextGame.text =
                $"Сумма:{_summ}. Игра окончена! Количество ходов: {_numberOfAttempts}. Нажми пробел для рестарта.";
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isWin)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    #endregion
}