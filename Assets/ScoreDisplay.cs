using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Numerics;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private TMP_Text _highScoreDisplay;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
        _player.ScoreChanged += OnHighScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
        _player.ScoreChanged -= OnHighScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreDisplay.text = score.ToString();
    }

    private void OnHighScoreChanged(int highScore)
    {
        _highScoreDisplay.text = highScore.ToString();
    }
}
