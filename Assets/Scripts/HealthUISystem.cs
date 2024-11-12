using UnityEngine;
using UnityEngine.UI;

public class HealthUISystem : MonoBehaviour
{
    [field: SerializeField]
    public Slider HealthBar { get; private set; }

    public void InitHealthBar(float maxValue)
    {
        HealthBar.maxValue = maxValue;
        HealthBar.minValue = 0;
        HealthBar.value = maxValue;
    }

    public void SetHealthBar(float value)
    {
        HealthBar.value = value;
    }
}
