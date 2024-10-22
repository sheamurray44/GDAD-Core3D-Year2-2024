using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler
{
    public static event Action<string> OnPlayerNameChanged;
    public static event Action<int> OnPlayerHealthChanged;
    public static event Action<int> OnScoreChanged;

    public static void PlayerNameChanged(string playerName)
    {
        OnPlayerNameChanged?.Invoke(playerName);
    }

    public static void PlayerHealthChanged(int playerHealth)
    {
        OnPlayerHealthChanged?.Invoke(playerHealth);
    }

    public static void ScoreChanged(int score)
    {
        OnScoreChanged?.Invoke(score);
    }
}
