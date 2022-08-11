using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    public class Location : MonoBehaviour
    {
        public event UnityAction<Location> Completed;

        [SerializeField] private Transform _playerPoint;
        [SerializeField] private List<Enemy> _enemies;

        public Transform PlayerPoint => _playerPoint;
        public bool IsComplete => _enemies.Count == 0;

        private void OnEnable()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Died += OnEnemyDied;
            }
        }

        private void OnDisable()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Died -= OnEnemyDied;
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            _enemies.Remove(enemy);

            CheckComplete();
        }

        private void CheckComplete()
        {
            if (IsComplete == true)
            {
                Completed?.Invoke(this);
            }
        }
    }
}
