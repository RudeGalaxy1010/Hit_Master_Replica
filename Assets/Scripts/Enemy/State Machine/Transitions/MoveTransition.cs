using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    public class MoveTransition : EnemyTransition
    {
        [SerializeField] private Location _location;

        private PlayerMove _playerMove;

        private void Start()
        {
            _playerMove = Target.GetComponent<PlayerMove>();
            _playerMove.PositionReached += OnPlayerPositionReached;
        }

        private void OnPlayerPositionReached(Location location)
        {
            if (_location == location)
            {
                _playerMove.PositionReached -= OnPlayerPositionReached;
                NeedTransit = true;
            }
        }
    }
}
