using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace HitMasterReplica
{
    public class BulletPool : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _startBulletsCount;

        private List<Bullet> _bullets;

        private void Start()
        {
            _bullets = new List<Bullet>(_startBulletsCount);

            for (int i = 0; i < _startBulletsCount; i++)
            {
                CreateBullet();
            }
        }

        public Bullet GetBullet()
        {
            Bullet bullet = _bullets.FirstOrDefault(b => b.gameObject.activeSelf == false);

            if (bullet == null)
            {
                bullet = CreateBullet();
            }

            bullet.Expired += OnBulletExpired;
            bullet.transform.SetParent(null);
            bullet.gameObject.SetActive(true);
            return bullet;
        }

        private void OnBulletExpired(Bullet bullet)
        {
            bullet.Expired -= OnBulletExpired;
            bullet.gameObject.SetActive(false);
            bullet.transform.position = transform.position;
            bullet.transform.SetParent(transform);
        }

        private Bullet CreateBullet()
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(transform);
            _bullets.Add(bullet);
            return bullet;
        }
    }
}
