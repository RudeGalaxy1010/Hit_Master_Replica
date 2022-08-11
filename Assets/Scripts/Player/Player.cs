using System;
using UnityEngine;

namespace HitMasterReplica
{
    public class Player : MonoBehaviour
    {
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
            throw new NotImplementedException();
        }
    }
}
