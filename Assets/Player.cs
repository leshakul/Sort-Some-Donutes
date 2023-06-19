using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private ShowReward _reward;
    [SerializeField] private LeaderBoardView _leaderboard;
    private int _score = 0;
    private int _highScore = 0;

    public event UnityAction<int> ScoreChanged;

    public int GetScore()
    {
        return _score;
    }

    public void ScoreChange()
    {
        if (_reward.GetIsPlayReward() == true)
        {
            _score += 3;
        }
        else
        {
            _score += 1;
        }

        ScoreChanged?.Invoke(_score);
        _leaderboard.SetLeaderboardScore();
        
        if (_score > _highScore)
        {
            _highScore = _score;
            ScoreChanged?.Invoke(_highScore);
        }
    }
}
