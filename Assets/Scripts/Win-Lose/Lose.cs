using System;
using UnityEngine;
using HitMasterReplica.UI;

namespace HitMasterReplica
{
    public class Lose : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private LoseScreen _loseScreen;

        private void OnEnable()
        {
            _level.Failed += OnLevelFailed;
        }

        private void OnDisable()
        {
            _level.Failed -= OnLevelFailed;
        }

        private void OnLevelFailed()
        {
            _loseScreen.Show();
        }
    }
}
