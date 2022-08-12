using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HitMasterReplica.UI
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private Level _level;
        [SerializeField] private Button _continueButton;

        private void OnEnable()
        {
            _level.Completed += OnLevelCompleted;
            _continueButton.onClick.AddListener(OnContinueButtonClick);
        }

        private void OnDisable()
        {
            _level.Completed -= OnLevelCompleted;
            _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        private void OnLevelCompleted()
        {
            gameObject.SetActive(true);
        }

        private void OnContinueButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
