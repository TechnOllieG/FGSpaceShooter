using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene
{
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
