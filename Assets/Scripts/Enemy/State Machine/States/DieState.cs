using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    public class DieState : EnemyState
    {
        [SerializeField] private float _dieDelay = 0.5f;

        private void OnEnable()
        {
            Destroy(gameObject, _dieDelay);
        }
    }
}
