
using TimeManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private TimeManager timeManager;
        public TimeManager TimeManager => timeManager;
        protected override void Cleanup()
        {
        }
        protected override void Initialize()
        {
        }
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}