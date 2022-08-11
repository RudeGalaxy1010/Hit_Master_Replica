using UnityEngine;

namespace HitMasterReplica
{
    public class Shooting : MonoBehaviour
    {
        private const float ScreenPositionZ = 100;

        [SerializeField] private Camera _camera;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Weapon _weapon;

        private void OnEnable()
        {
            _inputReader.Taped += Shoot;
        }

        private void OnDisable()
        {
            _inputReader.Taped -= Shoot;
        }

        private void Shoot(Vector2 screenPosition)
        {
            Vector3 screenPoint = new Vector3(screenPosition.x, screenPosition.y, ScreenPositionZ);
            Vector3 worldPoint = _camera.ScreenToWorldPoint(screenPoint);
            Vector3 direction = worldPoint - _weapon.ShootPointPosition;
            _weapon.TryShoot(direction / direction.magnitude);
        }
    }
}
