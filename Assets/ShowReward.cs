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

    public bool GetIsPlayReward()
    {
        return _isPlayReward;
    }

    public void ClosePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void PlayRewardOnButtonClick()
    {
        VideoAd.Show(_music.OffMusicInReward, ChangeIsPlayReward, _music.OnMusic);
        OpenPanel();
    }

    private void ChangeIsPlayReward()
    {
        _isPlayReward = true;
    }

    private void OpenPanel()
    {
        _panel.SetActive(true);
    }  

    private void OnMusic(bool obj)
    {
        if (obj)
        {
            _music.OnMusic();
        }  
    }
}
