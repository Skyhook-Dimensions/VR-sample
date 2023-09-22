using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine;

namespace Assets._Scripts.UI
{
    public class PanelScaler : MonoBehaviour
    {
        [SerializeField] private float _scaleDuration = 0.5f;

        private Transform _panelTransform;
        private Vector3 _originalScale;
        private CanvasTrigger _canvasTrigger;

        private void Awake()
        {
            _canvasTrigger = FindObjectOfType<CanvasTrigger>();
            _panelTransform = GetComponent<Transform>();
            _originalScale = Vector3.one;
            _panelTransform.localScale = Vector3.zero;
        }

        public void ScaleUpPanel()
        {
            // scale the panel to its original size
            _panelTransform.DOScale(_originalScale, _scaleDuration);
        }

        public void ScaleDownPanel()
        {
            // scale the panel to zero
            _panelTransform.DOScale(Vector3.zero, _scaleDuration * 0.5f);
        }

        public void ButtonClick(string newPanelName)
        {
            _canvasTrigger.ChangePanel(newPanelName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadScene(int SceneIndex)
        {
            SceneManager.LoadScene(SceneIndex);
        }
    }
}