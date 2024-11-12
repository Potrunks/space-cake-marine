using Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveSystem : MonoBehaviour
{
    [field: SerializeField]
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField]
    public PlayableCharacterData PlayableCharacterData { get; private set; }

    [field: SerializeField]
    public EnemyAnimationStateSystem AnimationState { get; private set; }

    private void Awake()
    {
        Agent.isStopped = true;
    }

    private void Update()
    {
        Transform target = PlayableCharacterData.PlayableCharactersInGame[0].transform;

        if (target.position.x != transform.position.x || target.position.z != transform.position.z)
        {
            Agent.SetDestination(PlayableCharacterData.PlayableCharactersInGame[0].transform.position);
            AnimationState.ExecuteRunningAnimation();
        }
        else
        {
            AnimationState.ExecuteIdleAnimation();
        }
    }
}
