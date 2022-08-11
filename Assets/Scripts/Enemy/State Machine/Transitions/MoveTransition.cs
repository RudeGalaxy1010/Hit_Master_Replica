using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    public class MoveTransition : Transition
    {
        private PlayerMove _playerMove;

        private void Start()
        {
            _playerMove = Target.GetComponent<PlayerMove>();
        }

        private void Update()
        {
            if (_playerMove.IsOnPosition)
            {
                NeedTransit = true;
            }
        }
    }
}
