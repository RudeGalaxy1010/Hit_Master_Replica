using UnityEngine;
using UnityEngine.AI;

namespace HitMasterReplica
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMove : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private Vector3 _target;

        public bool IsOnPosition => transform.position.x == _target.x && transform.position.z == _target.z;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _target = transform.position;
        }

        public void TryMoveToNextPoint(Vector3 point)
        {
            _target = point;
            _agent.SetDestination(point);
        }
    }
}
