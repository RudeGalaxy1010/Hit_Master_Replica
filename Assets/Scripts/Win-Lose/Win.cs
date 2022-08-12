using System;
using UnityEngine;
using HitMasterReplica.UI;

namespace HitMasterReplica
{
    public class Win : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private WinScreen _winScreen;

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
            _winScreen.Show();
        }
    }
}
