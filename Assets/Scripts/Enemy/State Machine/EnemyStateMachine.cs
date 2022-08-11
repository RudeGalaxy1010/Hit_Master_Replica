using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State _initialState;

        private Player _target;
        private State _currentState;

        public State CurrentState => _currentState;

        private void Start()
        {
            _target = GetComponent<Enemy>().Target;
            ResetState();
        }

        private void Update()
        {
            if (_currentState == null)
            {
                return;
            }

            State nextState = _currentState.GetNextState();
            if (nextState != null)
            {
                Transit(nextState);
            }
        }

        private void ResetState()
        {
            _currentState = _initialState;

            if (_currentState != null)
            {
                _currentState.Enter(_target);
            }
        }

        private void Transit(State state)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }

            _currentState = state;

            if (_currentState != null)
            {
                _currentState.Enter(_target);
            }
        }
    }
}
