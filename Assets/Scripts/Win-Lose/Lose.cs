using System;
using UnityEngine;

namespace HitMasterReplica
{
    public class Lose : MonoBehaviour
    {
        [SerializeField] private Level _level;

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
            throw new NotImplementedException();
        }
    }
}
