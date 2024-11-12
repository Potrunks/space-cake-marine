using Assets.Scripts.ScriptableObjects;
using UnityEngine;

public class EnemyFightSystem : MonoBehaviour
{
    [field: Header("--- Datas ---")]
    [field: SerializeField]
    public PlayableCharacterData PlayableCharacterData { get; private set; }

    [field: SerializeField]
    public Enemy Enemy { get; private set; }

    [field: Header("--- Components ---")]
    [field: SerializeField]
    public EnemyAnimationStateSystem AnimationState { get; private set; }

    [field: Header("--- Parameters ---")]
    [field: SerializeField]
    public float FightDistance { get; private set; }

    [field: SerializeField]
    public float LightAttackStart { get; private set; }

    [field: SerializeField]
    public float LightAttackEnd { get; private set; }

    private bool _hasTryToHitPlayer = false;

    private void Update()
    {
        Transform target = PlayableCharacterData.PlayableCharactersInGame[0].transform;

        if (IsPlayerIntoFightDistance(target))
        {
            AnimationState.ExecuteLightAttackAnimation();
        }
    }

    private bool IsPlayerIntoFightDistance(Transform target)
    {
        Vector3 relativePos = target.position - transform.position;
        bool isInFront = Vector3.Dot(transform.forward, relativePos) > 0.0f;
        return (Mathf.Abs(target.position.x - transform.position.x) <= FightDistance) && (Mathf.Abs(target.position.z - transform.position.z) <= FightDistance) && isInFront;
    }

    public void TryLightAttackPlayer(AnimatorStateInfo animatorStateInfo)
    {
        if (!_hasTryToHitPlayer && animatorStateInfo.normalizedTime >= LightAttackStart && animatorStateInfo.normalizedTime <= LightAttackEnd)
        {
            _hasTryToHitPlayer = true;

            Transform target = PlayableCharacterData.PlayableCharactersInGame[0].transform;
            if (IsPlayerIntoFightDistance(target))
            {
                PlayableCharacterDamageSystem damageSystem = target.GetComponent<PlayableCharacterDamageSystem>();
                damageSystem.TakeBodyDamage(Enemy.Force);
            }
        }
    }

    public void OnEnemyFinishLightAttackAnimation()
    {
        _hasTryToHitPlayer = false;
    }
}
