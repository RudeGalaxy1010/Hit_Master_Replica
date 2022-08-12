using UnityEngine;

namespace HitMasterReplica.StateMachine
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private EnemyState _initialState;

        private Player _target;
        private EnemyState _currentState;

        public EnemyState CurrentState => _currentState;

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

            EnemyState nextState = _currentState.GetNextState();
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

        private void Transit(EnemyState state)
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
