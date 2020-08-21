using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG
{
    public class Menu : MonoBehaviour
    {
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
