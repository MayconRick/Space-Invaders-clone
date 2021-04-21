using UnityEngine.SceneManagement;
using UnityEngine;

public class GameActions : MonoBehaviour
{

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
