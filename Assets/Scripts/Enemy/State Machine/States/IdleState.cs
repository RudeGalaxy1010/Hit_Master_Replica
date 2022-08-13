using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    [RequireComponent(typeof(Animator))]
    public class IdleState : EnemyState
    {
        private const float MaxTimeToStartWatching = 3;

        private Animator _animator;
        private float _timer;
        private bool _isWatching;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _isWatching = false;
        }

        private void OnEnable()
        {
            _timer = Random.Range(0, MaxTimeToStartWatching);
        }

        private void Update()
        {
            if (_isWatching == true)
            {
                return;
            }

            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _animator.SetTrigger(EnemyAnimatorConstants.IdleAnimation);
                _isWatching = true;
            }
        }
    }
}
