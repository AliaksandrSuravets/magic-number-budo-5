using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class StartMenu : MonoBehaviour
    {
        #region Variables

        public Button ExitButton;
        public Button StartButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            StartButton.onClick.AddListener(OnStartButtonClicked);
            ExitButton.onClick.AddListener(OnExitButtonClicked);
        }

        #endregion

        #region Private methods

        private void OnExitButtonClicked()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            //Application.Quit();
        }

        private void OnStartButtonClicked()
        {
            SceneManager.LoadScene(SceneName.Game);
        }

        #endregion
    }
}