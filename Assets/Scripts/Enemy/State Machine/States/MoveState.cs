using UnityEngine;
using UnityEngine.AI;

namespace HitMasterReplica.StateMachine
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
    public class MoveState : EnemyState
    {
        private const float _destinationThreshold = 0.1f;

        private NavMeshAgent _agent;
        private Animator _animator;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Vector3 moveDirection = transform.position - Target.transform.position;
            Vector3 stopOffset = moveDirection.normalized * transform.localScale.z;
            _agent.SetDestination(Target.transform.position + stopOffset);
            _animator.SetBool(EnemyAnimatorConstants.RunAnimation, true);
        }

        private void Update()
        {
            if (_agent.remainingDistance <= _destinationThreshold)
            {
                _animator.SetBool(EnemyAnimatorConstants.RunAnimation, false);
            }
        }

        private void OnDisable()
        {
            if (_agent.remainingDistance > _destinationThreshold)
            {
                _agent.SetDestination(transform.position);
                _animator.SetBool(EnemyAnimatorConstants.RunAnimation, false);
            }
        }
    }
}
