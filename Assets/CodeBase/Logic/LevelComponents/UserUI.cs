﻿using TMPro;

namespace CodeBase.Logic.LevelComponents
{
    public class UserUI : LevelComponent
    {
        private const string _scoreLine = "Score : ";

        public TextMeshProUGUI UserScoreText;

        private int _points;

        public void AddScore(int pointsCount)
        {
            _points += pointsCount;

            UserScoreText.text = _scoreLine + _points;
        }
    }
}