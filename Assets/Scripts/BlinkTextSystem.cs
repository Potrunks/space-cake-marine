using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkTextSystem : MonoBehaviour
{
    [field: SerializeField]
    public float BlinkSpeed { get; private set; }

    [field: SerializeField]
    public TextMeshProUGUI Text { get; private set; }

    private bool _isActive = false;

    private void OnEnable()
    {
        _isActive = true;
        StartCoroutine(BlinkTextCoroutine());
    }

    private void OnDisable()
    {
        _isActive = false;
        StopCoroutine(BlinkTextCoroutine());
    }

    private IEnumerator BlinkTextCoroutine()
    {
        while (_isActive)
        {
            Text.DOFade(0f, BlinkSpeed);
            yield return new WaitForSeconds(BlinkSpeed);
            Text.DOFade(1f, BlinkSpeed);
            yield return new WaitForSeconds(BlinkSpeed);
        }
    }
}
