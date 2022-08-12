using UnityEngine;
using UnityEngine.UI;

namespace HitMasterReplica.UI
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private Slider _slider;

        private void Awake()
        {
            _slider.maxValue = _enemy.Health;
        }

        private void OnEnable()
        {
            _enemy.HealthChanged += OnEnemyHealthChanged;
        }

        private void OnDisable()
        {
            _enemy.HealthChanged -= OnEnemyHealthChanged;
        }

        private void OnEnemyHealthChanged(int value)
        {
            _slider.value = value;
        }
    }
}
