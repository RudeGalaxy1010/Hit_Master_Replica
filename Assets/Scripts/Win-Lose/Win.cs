using System;
using UnityEngine;

namespace HitMasterReplica
{
    public class Win : MonoBehaviour
    {
        [SerializeField] private Level _level;

        private void OnEnable()
        {
            _level.Completed += OnLevelCompleted;
        }

        private void OnDisable()
        {
            _level.Completed -= OnLevelCompleted;
        }

        private void OnLevelCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
