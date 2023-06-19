using System;
using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using UnityEngine;

public class ShowReward : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private Music _music;

    private bool _isPlayReward = false;

    public void PlayRewardAfterDie()
    {
        InterstitialAd.Show(_music.OffMusicInReward, OnMusic);
    }

    private void OnMusic(bool obj)
    {
        if (obj)
        {
            _music.OnMusic();
        }  
    }

    public bool GetIsPlayReward()
    {
        return _isPlayReward;
    }

    public void PlayRewardOnButtonClick()
    {
        VideoAd.Show(_music.OffMusicInReward, isPlayReward, _music.OnMusic);
        OpenPanel();      
    }

    public void isPlayReward()
    {
        _isPlayReward = true;
    }

    public void OpenPanel()
    {
        _panel.SetActive(true);
    }

    public void ClosePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
