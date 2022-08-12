using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    [RequireComponent(typeof(Animator))]
    public class WinState : EnemyState
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            // TODO: create class for animator constants
            _animator.Play("Win");
        }

        private void OnDisable()
        {
            _animator.StopPlayback();
        }
    }
}
