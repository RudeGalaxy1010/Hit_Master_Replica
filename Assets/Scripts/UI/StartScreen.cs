using UnityEngine;

namespace HitMasterReplica.UI
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private GameObject _progressBar;

        private void OnEnable()
        {
            _level.GameStarted += OnGameStarted;
        }

        private void OnDisable()
        {
            _level.GameStarted -= OnGameStarted;
        }

        private void OnGameStarted()
        {
            gameObject.SetActive(false);
            _progressBar.SetActive(true);
        }
    }
}
