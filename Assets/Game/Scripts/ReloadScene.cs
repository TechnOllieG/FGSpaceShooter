using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    [SerializeField]
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
