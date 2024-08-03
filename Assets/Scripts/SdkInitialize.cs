using Agava.YandexGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SdkInitialize : MonoBehaviour
{
    [SerializeField] private Localization _localization;

    private void Awake()
    {
        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
        yield return YandexGamesSdk.Initialize();
        _localization.ChangeLocalization();
    }
}