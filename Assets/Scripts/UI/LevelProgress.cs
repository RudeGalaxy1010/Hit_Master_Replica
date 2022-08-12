using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HitMasterReplica.UI
{
    public class LevelProgress : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private Slider _progressBar;
        [SerializeField] private TMP_Text _progressText;

        private int _maxLocationsCount;

        private void Awake()
        {
            _maxLocationsCount = _level.LocationsCount;
            _progressBar.maxValue = _level.LocationsCount / _maxLocationsCount;
        }

        private void OnEnable()
        {
            _level.LocationCompleted += OnLocationCompleted;
        }

        private void OnDisable()
        {
            _level.LocationCompleted -= OnLocationCompleted;
        }

        private void OnLocationCompleted()
        {
            float progress = 1 - ((float)_level.LocationsCount / _maxLocationsCount);
            _progressBar.value = progress;
            _progressText.text = string.Format("{0}%", progress * 100f);
        }
    }
}
