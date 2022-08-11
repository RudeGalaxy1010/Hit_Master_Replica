using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public abstract class Transition : MonoBehaviour
    {
        [SerializeField] private State _targetState;

        protected Player Target { get; private set; }
        protected Enemy Enemy { get; private set; }

        public State TargetState => _targetState;
        public bool NeedTransit { get; protected set; }

        public void Init(Player target)
        {
            Target = target;
            Enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            NeedTransit = false;
        }
    }
}
