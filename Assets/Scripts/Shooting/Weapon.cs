using UnityEngine;

namespace HitMasterReplica
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _cooldownTime;

        private bool _isCooldown;
        private float _colldownTimer;

        public Vector3 ShootPointPosition => _shootPoint.position;

        private void Start()
        {
            _colldownTimer = 0;
        }

        private void Update()
        {
            if (_isCooldown == false)
            {
                return;
            }

            _colldownTimer += Time.deltaTime;

            if (_colldownTimer >= _cooldownTime)
            {
                _isCooldown = false;
            }
        }

        public void TryShoot(Vector3 direction)
        {
            if (_isCooldown == true)
            {
                return;
            }

            Bullet bullet = _bulletPool.GetBullet();
            bullet.transform.position = ShootPointPosition;
            bullet.Init(direction, _bulletSpeed);

            _isCooldown = true;
        }
    }
}
