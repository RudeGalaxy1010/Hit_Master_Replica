using System.Collections.Generic;
using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    public abstract class EnemyState : MonoBehaviour
    {
        [SerializeField] private List<EnemyTransition> _transitions;

        protected Player Target { get; private set; }

        public void Enter(Player target)
        {
            if (enabled == false)
            {
                Target = target;
                enabled = true;

                for (int i = 0; i < _transitions.Count; i++)
                {
                    _transitions[i].enabled = true;
                    _transitions[i].Init(Target);
                }
            }
        }

        public void Exit()
        {
            if (enabled == true)
            {
                for (int i = 0; i < _transitions.Count; i++)
                {
                    _transitions[i].enabled = false;
                }

                enabled = false;
            }
        }

        public EnemyState GetNextState()
        {
            for (int i = 0; i < _transitions.Count; i++)
            {
                if (_transitions[i].NeedTransit)
                {
                    return _transitions[i].TargetState;
                }
            }

            return null;
        }
    }
}
