using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HitMasterReplica.UI
{
    public class WinScreen : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;

        private void OnEnable()
        {
            _continueButton.onClick.AddListener(OnContinueButtonClick);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(OnContinueButtonClick);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void OnContinueButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
