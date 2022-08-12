using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    public class Location : MonoBehaviour
    {
        public event UnityAction<Location> Completed;
        public event UnityAction<Location> Failed;

        [SerializeField] private Transform _playerPoint;
        [SerializeField] private List<Enemy> _enemies;
        [SerializeField] private List<Civilian> _civilians;

        private int _startCiviliansCount;

        public Transform PlayerPoint => _playerPoint;
        public bool IsComplete => _enemies.Count == 0;
        public bool IsFailed => _civilians.Count < _startCiviliansCount;

        private void Awake()
        {
            _startCiviliansCount = _civilians.Count;
        }

        private void OnEnable()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Died += OnEnemyDied;
            }

            foreach (Civilian civilian in _civilians)
            {
                civilian.Died += OnCivilianDied;
            }
        }

        private void OnDisable()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.Died -= OnEnemyDied;
            }

            foreach (Civilian civilian in _civilians)
            {
                civilian.Died -= OnCivilianDied;
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            _enemies.Remove(enemy);

            CheckStatus();
        }

        private void OnCivilianDied(Civilian civilian)
        {
            civilian.Died -= OnCivilianDied;
            _civilians.Remove(civilian);

            CheckStatus();
        }

        private void CheckStatus()
        {
            if (IsFailed)
            {
                Failed?.Invoke(this);
            }
            else if (IsComplete == true)
            {
                Completed?.Invoke(this);
            }
        }
    }
}
