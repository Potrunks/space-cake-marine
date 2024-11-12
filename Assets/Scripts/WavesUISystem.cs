using Assets.Scripts.GameEvents.ScriptableObjects;
using System.Collections;
using TMPro;
using UnityEngine;

public class WavesUISystem : MonoBehaviour
{
    [field: SerializeField]
    public TextMeshProUGUI WaveNumberText { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI WaveTimerText { get; private set; }

    [field: SerializeField]
    public GameEvent OnWaveTimerOver { get; private set; }

    private int _currentWaveNumber = 0;

    public void ActivateNewWaveCountdown(float waveDuration)
    {
        _currentWaveNumber++;
        WaveNumberText.text = $"Wave {_currentWaveNumber}";
        StartCoroutine(UpdateWaveTimerCoroutine(waveDuration));
    }

    private IEnumerator UpdateWaveTimerCoroutine(float waveDuration)
    {
        float remainingTimer = waveDuration;
        while (remainingTimer > 0)
        {
            remainingTimer -= Time.deltaTime;
            int minutes = Mathf.Max(Mathf.FloorToInt(remainingTimer / 60), 0);
            int seconds = Mathf.Max(Mathf.FloorToInt(remainingTimer % 60), 0);
            WaveTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            yield return null;
        }
        OnWaveTimerOver.Raise();
    }
}
