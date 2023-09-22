using UnityEngine;

namespace Assets._Scripts.UI
{
    public class LookAt : MonoBehaviour   
    {
        private Player _player;

        private void Start()
        {
            _player = FindAnyObjectByType<Player>();
        }

        // Update is called once per frame
        private void Update()
        {
            // Rotate the panel to look away from the camera (cuz the canvas are reversed)
            //  ------------------(use player position instead?)------------------
            this.transform.rotation = Quaternion.LookRotation(this.transform.position - _player.transform.position);
        }
    }
}
