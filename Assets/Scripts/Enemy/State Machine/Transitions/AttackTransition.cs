using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    public class AttackTransition : Transition
    {
        [SerializeField] private float _attackDistance;

        private void Update()
        {
            if (Vector3.Distance(Target.transform.position, transform.position) <= _attackDistance)
            {
                NeedTransit = true;
            }
        }
    }
}
