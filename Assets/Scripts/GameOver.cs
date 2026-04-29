using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
     public void returnToMainMenu()
    {
        Global.instance.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void restart()
    {
        Global.instance.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
