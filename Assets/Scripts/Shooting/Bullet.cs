using UnityEngine;
using UnityEngine.Events;

namespace HitMasterReplica
{
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        public event UnityAction<Bullet> Expired;

        [SerializeField] private int _damage;

        private Vector3 _direction;
        private float _speed;
        private Vector3 _startPosition;
        private float _maxDistance;
        private bool _isInited;

        public int Damage => _damage;

        private void Start()
        {
            _startPosition = transform.position;
        }

        public void Init(Vector3 direction, float speed, float maxDistance = 100)
        {
            _direction = direction;
            _speed = speed;
            _maxDistance = maxDistance;
            _isInited = true;
        }

        private void Update()
        {
            if (_isInited == false)
            {
                return;
            }

            Move();
            CheckDistance();
        }

        private void OnTriggerEnter(Collider other)
        {
            Expired?.Invoke(this);
        }

        private void Move()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        private void CheckDistance()
        {
            if (Vector3.Distance(_startPosition, transform.position) >= _maxDistance)
            {
                Expired?.Invoke(this);
            }
        }
    }
}
