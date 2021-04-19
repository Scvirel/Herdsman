using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic.LevelComponents
{
    public class UserUI : LevelComponent
    {
        private const string _scoreLine = "Score : ";

        public TextMeshProUGUI UserScoreText;
        public Button ExitButton;

        private int _points;

        private void Awake() => 
            ExitButton.onClick.AddListener(OnExitButtonClick);
        private void OnDestroy() => 
            ExitButton.onClick.RemoveListener(OnExitButtonClick);

        public void AddScore(int pointsCount)
        {
            _points += pointsCount;

            UserScoreText.text = _scoreLine + _points;
        }

        private void OnExitButtonClick() => 
            Application.Quit();
    }
}