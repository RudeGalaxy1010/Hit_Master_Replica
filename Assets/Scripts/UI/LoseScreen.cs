using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HitMasterReplica.UI
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _level.Failed += OnLevelFailed;
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDisable()
        {
            _level.Failed -= OnLevelFailed;
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnLevelFailed()
        {
            gameObject.SetActive(true);
        }

        private void OnRestartButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
