using UnityEngine;
using System.Linq;
using TMPro;


public class EventListener : MonoBehaviour
{
    public TextMeshProUGUI logText;
    public int lineCount = 10;
    private void OnEnable()
    {
        // Subscribe to events
        HealthEventManager.OnObjectDamaged += HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed += HandleObjectDestroyed;
    }

    private void OnDisable()
    {
        // Unsubscribe from events to avoid memory leaks
        HealthEventManager.OnObjectDamaged -= HandleObjectDamaged;
        HealthEventManager.OnObjectDestroyed -= HandleObjectDestroyed;
    }

    private void HandleObjectDamaged(string name, int remainingHealth)
    {
        string message = $"An object called {name} was damaged! Remaining Health: {remainingHealth}";
        Debug.Log(message);
        UpdateLog(message, lineCount);
    }

    private void HandleObjectDestroyed(string name, int remainingHealth)
    {
        string message = $"An object called {name} was destroyed!";
        Debug.Log(message);
        UpdateLog(message, lineCount);
    }

    private void UpdateLog(string message, int maxLines)
    {
        if (logText != null)
        {
            var lines = logText.text.Split('\n').ToList();
            lines.Add(message);
            if (lines.Count > maxLines)
            {
                lines.RemoveAt(0);
            }

            logText.text = string.Join("\n", lines);
        }
    }
    
}