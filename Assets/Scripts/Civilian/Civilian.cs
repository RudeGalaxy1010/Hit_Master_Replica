using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    [RequireComponent(typeof(Collider))]
    public class Civilian : MonoBehaviour
    {
        public event UnityAction<Civilian> Died;

        [SerializeField] private int _health;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Bullet bullet))
            {
                TakeDamage(bullet.Damage);
            }
        }

        private void TakeDamage(int value)
        {
            _health -= value;

            if (_health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Died?.Invoke(this);
            Destroy(gameObject, 0.7f);
        }
    }
}
