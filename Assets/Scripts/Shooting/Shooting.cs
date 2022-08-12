using UnityEngine;

namespace HitMasterReplica
{
    public class Shooting : MonoBehaviour
    {
        private const float MaxRayLength = 100;

        [SerializeField] private Camera _camera;
        [SerializeField] private InputReader _inputReader;
        [SerializeField] private Weapon _weapon;
        [SerializeField] private LayerMask _shootingPLaneLayerMask;

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
            Ray ray = _camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, MaxRayLength, _shootingPLaneLayerMask))
            {
                _weapon.TryShoot((hit.point - _weapon.ShootPoint.position).normalized);
            }
        }
    }
}
