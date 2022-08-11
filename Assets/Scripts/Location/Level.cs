using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    public class Level : MonoBehaviour
    {
        public event UnityAction LevelComplete;

        [SerializeField] private PlayerMove _player;
        [SerializeField] private List<Location> _locations;

        private void OnEnable()
        {
            foreach (Location location in _locations)
            {
                location.Completed += OnLocationCompleted;
            }
        }

        private void OnDisable()
        {
            foreach (Location location in _locations)
            {
                location.Completed -= OnLocationCompleted;
            }
        }

        private void OnLocationCompleted(Location location)
        {
            location.Completed -= OnLocationCompleted;
            _locations.Remove(location);

            CheckComplete();
        }

        private void CheckComplete()
        {
            if (_locations.Count == 0)
            {
                LevelComplete?.Invoke();
            }
            else
            {
                _player.TryMoveToNextPoint(_locations[0].PlayerPoint.position);
            }
        }
    }
}
