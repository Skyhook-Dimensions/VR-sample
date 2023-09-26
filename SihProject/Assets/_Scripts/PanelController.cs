using UnityEngine;
using DG.Tweening;

namespace Assets._Scripts
{
    public class PanelController : MonoBehaviour
    {
        private void Awake()
        {
            transform.localScale = Vector3.zero;
        }

        public void Show()
        {
            transform.DOScale(1, 0.5f);
        }

        public void Hide()
        {
            transform.DOScale(0, 0.2f);
        }
    }
}