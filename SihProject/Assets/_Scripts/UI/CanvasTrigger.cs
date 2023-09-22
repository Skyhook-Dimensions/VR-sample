using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.UI
{
    [RequireComponent(typeof(Collider)), RequireComponent(typeof(Rigidbody))]
    public class CanvasTrigger : MonoBehaviour
    {
        public PanelScaler currentPanelScaler { get; private set; }

        private Dictionary<string, PanelScaler> _dictionary = new Dictionary<string, PanelScaler>();

        private void Awake()
        {
            var panelScalers = new List<PanelScaler>();
            panelScalers.AddRange(FindObjectsOfType<PanelScaler>());
            foreach (var panelScaler in panelScalers)
            {
                _dictionary.Add(panelScaler.name, panelScaler);
            }
            // empty the list
            panelScalers.Clear();
            currentPanelScaler = _dictionary["Main Panel"];
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>() != null)
            {
                currentPanelScaler.ScaleUpPanel();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Player>() != null)
            {
                currentPanelScaler.ScaleDownPanel();
                currentPanelScaler = _dictionary["Main Panel"];
            }
        }

        public void ChangePanel(string panelName)
        {
            currentPanelScaler.ScaleDownPanel();
            currentPanelScaler = _dictionary[panelName];
            currentPanelScaler.ScaleUpPanel();
        }
    }
}