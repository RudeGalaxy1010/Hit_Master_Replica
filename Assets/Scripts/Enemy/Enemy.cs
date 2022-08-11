using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    //[RequireComponent(typeof(Collider))]
    public class Enemy : MonoBehaviour
    {
        public event UnityAction<Enemy> Died;
        public event UnityAction<int> HealthChanged;

        [SerializeField] private Player _target;
        [SerializeField] private int _health;

        public int Health => _health;
        public Player Target => _target;

        private void Start()
        {
            HealthChanged?.Invoke(_health);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                TakeDamage(bullet.Damage);
            }
        }

        public void TakeDamage(int value)
        {
            _health -= value;
            HealthChanged?.Invoke(_health);

            if (_health <= 0)
            {
                Die();
            }
        }

        public void Die()
        {
            Died?.Invoke(this);
        }
    }
}
