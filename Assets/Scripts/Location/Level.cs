using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    public class Level : MonoBehaviour
    {
        public event UnityAction LevelComplete;
        public event UnityAction LevelFailed;

        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerMove _playerMove;
        [SerializeField] private List<Location> _locations;

        private void OnEnable()
        {
            _inputReader.Taped += OnTaped;
            _player.Died += OnPlayerDied;
            _playerMove.PositionReached += OnPlayerPosotionReached;

            foreach (Location location in _locations)
            {
                location.Completed += OnLocationCompleted;
            }
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
            LevelFailed?.Invoke();
        }

        private void CheckStatus(Location location)
        {
            if (location.IsFailed == true)
            {
                LevelFailed?.Invoke();
                return;
            }

            if (location.IsComplete == true)
            {
                location.Completed -= OnLocationCompleted;
                _locations.Remove(location);
            }

            if (_locations.Count == 0)
            {
                LevelComplete?.Invoke();
            }
            else
            {
                _playerMove.TryMoveToNextLocation(_locations[0]);
            }
        }
    }
}
