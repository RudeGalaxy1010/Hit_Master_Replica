using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HitMasterReplica.UI
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void OnRestartButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
