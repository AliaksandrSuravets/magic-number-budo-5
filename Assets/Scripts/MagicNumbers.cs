using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    public Button BelowButton;
    public Button GuessButton;
    public TMP_Text GuessLabel;
    public Button HigherButton;

    public int Max = 1000;
    public int Min = 1;
    public TMP_Text RulesFirstGame;
    public TMP_Text TextGame;
    private int _guess;
    private bool _isWin;
    private int _numberOfAttempts;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        RulesFirstGame.text =
            $"Загадай число от {Min} до {Max}. Нажмите стрелку вверх, если ваше число больше. Нажмите стрелку вниз, если ваше число меньше. Нажмите пробел, если я угадал.";
        CalculateGuess();
        _numberOfAttempts = 1;
        AskAboutGuess();

        HigherButton.onClick.AddListener(OnHigherButtonClicked);
        GuessButton.onClick.AddListener(OnGuessButtonClicked);
        BelowButton.onClick.AddListener(OnBelowButtonClicked);
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

    private void OnBelowButtonClicked()
    {
        if (_isWin)
        {
            return;
        }

        Max = _guess;
        CalculateGuess();
        AskAboutGuess();
        _numberOfAttempts++;
    }

    private void OnGuessButtonClicked()
    {
        if (_isWin)
        {
            SceneManager.LoadScene(SceneName.Win);
        }

        TextGame.text =
            $"Угадал твое чилсо {_guess}. Попыток - {_numberOfAttempts}.";
        _isWin = true;
        Destroy(HigherButton.gameObject);
        Destroy(BelowButton.gameObject);
        GuessLabel.text = "Exit";
    }

    private void OnHigherButtonClicked()
    {
        if (_isWin)
        {
            return;
        }

        Min = _guess;
        CalculateGuess();
        AskAboutGuess();
        _numberOfAttempts++;
    }

    #endregion
}