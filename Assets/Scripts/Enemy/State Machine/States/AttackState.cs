using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    public class AttackState : State
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _delay;

        private float _timer;

        private void OnEnable()
        {
            _timer = 0;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _timer = _delay;
                Attack(Target);
            }
        }

        private void Attack(Player target)
        {
            target.TakeDamage(_damage);
        }
    }
}
