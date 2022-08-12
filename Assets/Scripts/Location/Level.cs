using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    public class Level : MonoBehaviour
    {
        public event UnityAction Completed;
        public event UnityAction Failed;
        public event UnityAction LocationCompleted;
        public event UnityAction GameStarted;

        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Shooting _shooting;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private List<Location> _locations;

        public int LocationsCount => _locations.Count;

        private void OnEnable()
        {
            _inputReader.Taped += OnTaped;
            _player.Died += OnPlayerDied;
            _playerMove.PositionReached += OnPlayerPosotionReached;

            foreach (Location location in _locations)
            {
                location.Completed += OnLocationCompleted;
            }

            LocationCompleted?.Invoke();
        }

        private void OnDisable()
        {
            _inputReader.Taped -= OnTaped;
            _player.Died -= OnPlayerDied;
            _playerMove.PositionReached -= OnPlayerPosotionReached;

            foreach (Location location in _locations)
            {
                location.Completed -= OnLocationCompleted;
            }
        }

        private void OnTaped(Vector2 screenPosition)
        {
            _inputReader.Taped -= OnTaped;
            StartGame();
        }

        private void StartGame()
        {
            GameStarted?.Invoke();
            _shooting.enabled = true;
            OnLocationCompleted(_locations[0]);
        }

        private void OnLocationCompleted(Location location)
        {
            CheckStatus(location);
        }

        private void OnPlayerPosotionReached(Location location)
        {
            CheckStatus(location);
        }

        private void OnPlayerDied(Player player)
        {
            Failed?.Invoke();
        }

        private void CheckStatus(Location location)
        {
            if (location.IsFailed == true)
            {
                Failed?.Invoke();
                return;
            }

            if (location.IsComplete == true)
            {
                location.Completed -= OnLocationCompleted;
                _locations.Remove(location);
                LocationCompleted?.Invoke();
            }

            if (_locations.Count == 0)
            {
                Completed?.Invoke();
            }
            else
            {
                _playerMove.TryMoveToNextLocation(_locations[0]);
            }
        }
    }
}
