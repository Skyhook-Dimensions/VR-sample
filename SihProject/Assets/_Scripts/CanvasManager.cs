using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts
{
    public class CanvasManager : MonoBehaviour
    {
        private PanelController _currentPanel;

        private Dictionary<string, PanelController> _panels = new Dictionary<string, PanelController>();

        private void Awake()
        {
            foreach (var panel in GetComponentsInChildren<PanelController>())
            {
                _panels.Add(panel.name, panel);
            }
        }

        public void ShowPanel(string panelName)
        {
            _currentPanel = _panels[panelName];
            _currentPanel.Show();
        }

        public void HidePanel()
        {
            _currentPanel.Hide();
        }
    }
}