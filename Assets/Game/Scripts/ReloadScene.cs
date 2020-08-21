using UnityEngine;
using UnityEngine.SceneManagement;

namespace FG
{
    public class ReloadScene : MonoBehaviour
    {
        public void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
