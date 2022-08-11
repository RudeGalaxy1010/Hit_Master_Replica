using UnityEngine;
using UnityEngine.AI;

namespace HitMasterReplica
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;

        private int _currentPointIndex;
        private NavMeshAgent _agent;

        public bool IsCurrentPointLast => _currentPointIndex >= _points.Length - 1;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _currentPointIndex = 0;
        }

        public void TryMoveToNextPoint()
        {
            if (IsCurrentPointLast)
            {
                return;
            }

            _currentPointIndex++;
            _agent.SetDestination(_points[_currentPointIndex].position);
        }
    }
}
