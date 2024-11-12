using Assets.Scripts.ScriptableObjects;
using Cinemachine;
using System.Collections;
using UnityEngine;

public class PlayableCharacterCameraSystem : MonoBehaviour
{
    [field: SerializeField]
    public CinemachineFreeLook Cinemachine { get; private set; }

    [field: SerializeField]
    public Camera Camera { get; private set; }

    [field: Header("--- Zoom Parameters ---")]
    [field: SerializeField]
    public float AimZoomMultiplicator { get; private set; } = 2f;

    [field: SerializeField]
    public float CameraSpeedZoomDivider { get; private set; } = 2f;

    [field: Header("--- Shake Parameters ---")]
    [field: SerializeField]
    public float ShakeAmplitude { get; private set; } = 1f;

    [field: SerializeField]
    public float ShakeDuration { get; private set; } = 0.5f;

    private bool _isZoomRecoilingEffect = false;
    private bool _isRecoilingEffect = false;
    private bool _isShaking = false;
    private CinemachineBasicMultiChannelPerlin _channelPerlin;

    private void Start()
    {
        _channelPerlin = Cinemachine.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Aim()
    {
        Cinemachine.m_Lens.FieldOfView = Cinemachine.m_Lens.FieldOfView / AimZoomMultiplicator;

        Cinemachine.m_XAxis.m_MaxSpeed = Cinemachine.m_XAxis.m_MaxSpeed / CameraSpeedZoomDivider;
        Cinemachine.m_YAxis.m_MaxSpeed = Cinemachine.m_YAxis.m_MaxSpeed / CameraSpeedZoomDivider;
    }

    public void StopAim()
    {
        Cinemachine.m_Lens.FieldOfView = Cinemachine.m_Lens.FieldOfView * AimZoomMultiplicator;

        Cinemachine.m_XAxis.m_MaxSpeed = Cinemachine.m_XAxis.m_MaxSpeed * CameraSpeedZoomDivider;
        Cinemachine.m_YAxis.m_MaxSpeed = Cinemachine.m_YAxis.m_MaxSpeed * CameraSpeedZoomDivider;
    }

    public void DoZoomRecoilEffect(Gun gun)
    {
        _isZoomRecoilingEffect = true;
        _isRecoilingEffect = false;
        StartCoroutine(ZoomRecoilEffectCoroutine(gun));
    }

    public void DoRecoilEffect(Gun gun)
    {
        _isZoomRecoilingEffect = false;
        _isRecoilingEffect = true;
        StartCoroutine(RecoilEffectCoroutine(gun));
    }

    public void StopRecoilEffect()
    {
        _isZoomRecoilingEffect = false;
        _isRecoilingEffect = false;
    }

    public IEnumerator ZoomRecoilEffectCoroutine(Gun gun)
    {
        while (_isZoomRecoilingEffect)
        {
            Cinemachine.m_YAxis.Value = Cinemachine.m_YAxis.Value - (gun.ZoomRecoil * 0.1f / 100f);
            CheckEnemyHit(gun);
            yield return new WaitForSeconds(gun.FireRate);
        }
    }

    public IEnumerator RecoilEffectCoroutine(Gun gun)
    {
        while (_isRecoilingEffect)
        {
            Cinemachine.m_YAxis.Value = Cinemachine.m_YAxis.Value - (gun.Recoil * 0.1f / 100f);
            CheckEnemyHit(gun);
            yield return new WaitForSeconds(gun.FireRate);
        }
    }

    private void CheckEnemyHit(Gun gun)
    {
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0f);
        Ray rayFromScreenCenter = Camera.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(rayFromScreenCenter, out RaycastHit hit))
        {
            GameObject impact = Instantiate(gun.ImpactEffectPrefab, hit.point, hit.transform.rotation);
            impact.transform.LookAt(transform);

            EnemyDamageSystem enemyDamageSystem = hit.transform.gameObject.GetComponentInParent<EnemyDamageSystem>();
            if (enemyDamageSystem != null)
            {
                enemyDamageSystem.TakeGunDamage(gun.Damage);
            }
        }
    }

    public void ShakeCamera()
    {
        if (!_isShaking)
        {
            StartCoroutine(ShakeCameraCoroutine());
        }
    }

    private IEnumerator ShakeCameraCoroutine()
    {
        _isShaking = true;
        _channelPerlin.m_AmplitudeGain = ShakeAmplitude;
        yield return new WaitForSeconds(ShakeDuration);
        _channelPerlin.m_AmplitudeGain = 0f;
        _isShaking = false;
    }
}
