using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCinematicSystem : MonoBehaviour
{
    [field: Header("--- Robot Actor ---")]
    [field: SerializeField]
    public GameObject RobotActor { get; private set; }

    [field: SerializeField]
    public Animator RobotActorAnimator { get; private set; }

    [field: SerializeField]
    public float LookAtDuration { get; private set; }

    [field: SerializeField]
    public float LookAtSpeed { get; private set; }

    [field: SerializeField]
    public List<GameObject> ActorsToLookAt { get; private set; }

    [field: Header("--- Camera ---")]
    [field: SerializeField]
    public Camera MainCamera { get; private set; }

    [field: SerializeField]
    public List<Transform> CameraPositionSequences { get; private set; }

    [field: Header("--- Cinematic ---")]
    [field: SerializeField]
    public float GlobalTimeScale { get; private set; }

    private void Start()
    {
        Time.timeScale = GlobalTimeScale;
        RobotActorAnimator.Play("Run");
        StartCoroutine(RobotActorLookAtCoroutine());
    }

    private IEnumerator RobotActorLookAtCoroutine()
    {
        for (int i = 0; i < ActorsToLookAt.Count; i++)
        {
            RobotActor.transform.DOLookAt(ActorsToLookAt[i].transform.position, LookAtSpeed);

            MainCamera.transform.DOMove(CameraPositionSequences[i].transform.position, LookAtSpeed);
            MainCamera.transform.DORotateQuaternion(CameraPositionSequences[i].transform.rotation, LookAtSpeed);

            i = i == ActorsToLookAt.Count - 1 ? -1 : i;
            yield return new WaitForSeconds(LookAtDuration);
        }
    }
}
