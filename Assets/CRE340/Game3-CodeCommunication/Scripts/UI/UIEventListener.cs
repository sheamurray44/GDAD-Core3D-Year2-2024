using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIEventListener : MonoBehaviour
{
    private UI_Display uiDisplay;

    private void Awake()
    {
        uiDisplay = GetComponent<UI_Display>();
    }

    private void OnEnable()
    {
        UIEventHandler.OnPlayerNameChanged += UpdatePlayerName;
        UIEventHandler.OnPlayerHealthChanged += UpdatePlayerHealth;
        UIEventHandler.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        UIEventHandler.OnPlayerNameChanged -= UpdatePlayerName;
        UIEventHandler.OnPlayerHealthChanged -= UpdatePlayerHealth;
        UIEventHandler.OnScoreChanged -= UpdateScore;
    }

    private void UpdatePlayerName(string playerName)
    {

    }
}
