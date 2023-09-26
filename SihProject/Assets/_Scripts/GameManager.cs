using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Scripts
{
    public class GameManager : MonoBehaviour
    {
        private bool isPaused = false;
        private CanvasManager _canvasManager;

        // Start is called before the first frame update
        private void Start()
        {
            _canvasManager = FindObjectOfType<CanvasManager>();
            _canvasManager.ShowPanel("First");
            StartCoroutine(WaitAndPause(0.6f));
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
                Resume();
            else if (Input.GetKeyDown(KeyCode.Slash) && !isPaused)
                GoToMenu();
        }

        public void Pause()
        {
            isPaused = true;
            Time.timeScale = 0;
            // Cursor.lockState = CursorLockMode.None;
        }

        public void Resume()
        {
            // Cursor.lockState = CursorLockMode.Locked;
            isPaused = false;
            _canvasManager.HidePanel();
            Time.timeScale = 1;
        }

        private IEnumerator WaitAndPause(float time)
        {
            yield return new WaitForSeconds(time);
            Pause();
        }

        public void GoToMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}