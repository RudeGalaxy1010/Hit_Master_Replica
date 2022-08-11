using UnityEngine;
using UnityEngine.AI;

namespace HitMasterReplica.StateMachine
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveState : State
    {
        private NavMeshAgent _agent;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnEnable()
        {
            Vector3 moveDirection = transform.position - Target.transform.position;
            Vector3 stopOffset = moveDirection.normalized * transform.localScale.z;
            _agent.SetDestination(Target.transform.position + stopOffset);
        }

        private void OnDisable()
        {
            _agent.Stop();
        }
    }
}
