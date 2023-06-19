using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardView : MonoBehaviour
{
    [SerializeField] private Player _playerScore;
    [SerializeField] private GameObject _leaderboard;
    [SerializeField] private GameObject _authorizePanel;
    [SerializeField] private GameObject[] _players;
    [SerializeField] private TMP_Text[] _leaderNames;
    [SerializeField] private TMP_Text[] _scoreList;

    private string _leaderboardName = "leaderboard";

    public void OpenAuthorizationPanel()
    {
        if (!PlayerAccount.IsAuthorized)
        {
            _authorizePanel.SetActive(true);
            _leaderboard.SetActive(false);
        }
        else
        {
            OpenLeaderboardPanel();
        }
    }

    public void OpenYandexLeaderboard()
    {
        PlayerAccount.RequestPersonalProfileDataPermission();
        if (!PlayerAccount.IsAuthorized)
            PlayerAccount.Authorize();

        Leaderboard.GetEntries(_leaderboardName, (result) =>
        {
            int leadersNumber = result.entries.Length >= _leaderNames.Length ? _leaderNames.Length : result.entries.Length;
            for (int i = 0; i < leadersNumber; i++)
            {
                _players[i].SetActive(true);
                string name = result.entries[i].player.publicName;
                if (string.IsNullOrEmpty(name))
                    name = "Anonimus";
                _leaderNames[i].text = name;
                _scoreList[i].text = result.entries[i].formattedScore;
            }
        });
    }

    public void SetLeaderboardScore()
    {
        if (YandexGamesSdk.IsInitialized)
        {
            Leaderboard.GetPlayerEntry(_leaderboardName, OnSuccessCallback);
        }
    }

    public void CloseLeaderBoard()
    {
        _leaderboard.SetActive(false);
    }

    public void CloseAuthorizePanel()
    {
        _authorizePanel.SetActive(false);
        PlayerAccount.Authorize();
    }

    private void OpenLeaderboardPanel()
    {
        SetLeaderboardScore();
        OpenYandexLeaderboard();

        if (PlayerAccount.IsAuthorized)
        {
            _leaderboard.SetActive(true);
        }
    }

    private void OnSuccessCallback(LeaderboardEntryResponse result)
    {
        if (result == null || _playerScore.GetScore() > result.score)
        {
            Leaderboard.SetScore(_leaderboardName, _playerScore.GetScore());
        }
    }
}
