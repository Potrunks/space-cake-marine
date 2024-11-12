using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayableCharacterAimSystem : MonoBehaviour
{
    [field: SerializeField]
    public Transform BodyAimTarget { get; private set; }

    [field: SerializeField]
    public float AimMoveSmooth { get; private set; } = 20f;

    [field: SerializeField]
    public Camera Camera { get; private set; }

    [field: SerializeField]
    public float MaxTargetDistance { get; private set; }

    [field: SerializeField]
    public MultiAimConstraint MultiAimConstraint { get; private set; }

    private bool _isAiming = false;

    public void Aim()
    {
        _isAiming = true;
        MultiAimConstraint.data.offset = new Vector3(-5f, 40f, 0f);
        StartCoroutine(AimCoroutine());
    }

    public void StopAim()
    {
        _isAiming = false;
        StopCoroutine(nameof(AimCoroutine));
        BodyAimTarget.localPosition = new Vector3(0f, 0f, 500f);
        MultiAimConstraint.data.offset = Vector3.zero;
    }

    public IEnumerator AimCoroutine()
    {
        while (_isAiming)
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
            Ray rayFromScreenCenter = Camera.ScreenPointToRay(screenCenter);
            Vector3 targetPoint = rayFromScreenCenter.origin + rayFromScreenCenter.direction * MaxTargetDistance;
            BodyAimTarget.position = Vector3.Lerp(BodyAimTarget.position, targetPoint, AimMoveSmooth * Time.deltaTime);
            yield return null;
        }
    }
}
