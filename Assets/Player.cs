using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score = 0;
    private int _highScore = 0;

    public event UnityAction<int> ScoreChanged;

    public void ScoreChange()
    {
        _score += 1;
        ScoreChanged?.Invoke(_score);
        
        if (_score > _highScore)
        {
            _highScore = _score;
            ScoreChanged?.Invoke(_highScore);
        }
    }
}
