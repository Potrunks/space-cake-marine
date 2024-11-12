using Assets.Scripts.ScriptableObjects;
using UnityEngine;

public class EnemyDamageSystem : MonoBehaviour
{
    [field: SerializeField]
    public Enemy Enemy { get; private set; }

    [field: SerializeField]
    public EnemyAnimationStateSystem AnimationState { get; private set; }

    private float _healthPoint;

    private void Awake()
    {
        _healthPoint = Enemy.MaxHealthPoint;
    }

    public void TakeGunDamage(float damage)
    {
        if (AnimationState.CanTakeGunDamage())
        {
            _healthPoint -= damage;
            AnimationState.ExecuteGunDamageAnimation(_healthPoint <= 0f);
        }
    }
}
