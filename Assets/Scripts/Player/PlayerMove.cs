using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace HitMasterReplica
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMove : MonoBehaviour
    {
        private const float _destinationThreshold = 0.1f;

        public event UnityAction<Location> PositionReached;

        [SerializeField] private Animator _animator;

        private Location _currentLocation;
        private NavMeshAgent _agent;
        private Coroutine _onPositionCheckCoroutine;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        public void TryMoveToNextLocation(Location location)
        {
            if (_currentLocation == location)
            {
                return;
            }

            _currentLocation = location;
            _agent.SetDestination(location.PlayerPoint.position);
            _animator.SetBool(PlayerAnimatorConstants.RunAnimation, true);

            if (_onPositionCheckCoroutine != null)
            {
                StopCoroutine(_onPositionCheckCoroutine);
                _onPositionCheckCoroutine = null;
            }

            StartCoroutine(OnPositionCheck(location));
        }

        private IEnumerator OnPositionCheck(Location location)
        {
            yield return null; // Wait for end of frame to update NavMesh path with new location
            yield return new WaitUntil(() => _agent.remainingDistance <= _destinationThreshold);
            _animator.SetBool(PlayerAnimatorConstants.RunAnimation, false);
            PositionReached?.Invoke(location);
            _onPositionCheckCoroutine = null;
        }
    }
}
