using System;
using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    public class Player : MonoBehaviour
    {
        public event UnityAction<Player> Died;

        [SerializeField] private int _health;

        public int Health => _health;

        public void TakeDamage(int value)
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
        }
    }
}
