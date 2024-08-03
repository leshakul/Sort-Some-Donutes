using System;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _music;
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _musicOff;
    [SerializeField] private Sprite _musicOn;

    private void Start()
    {
        _music.volume = 0.2f;
    }

    public void OnMusic()
    {
        _music.volume = 0.2f;
    }

    public void OffMusicInReward()
    {
        _music.volume = 0;
    }

    public void OffMusic()
    {
        if(_music.volume != 0)
        {
            _music.volume = 0;
            _image.sprite = _musicOff;
        }
        else
        {
            _music.volume = 0.2f;
            _image.sprite = _musicOn;
        }
    }
}
