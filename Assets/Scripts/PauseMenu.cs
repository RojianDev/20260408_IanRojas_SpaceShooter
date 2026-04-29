using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] InputActionReference pauseAction;
    bool paused = false;
    void Awake()
    {
        pauseAction.action.started += OnPause;
    }

    void OnEnable()
    {
        pauseAction.action.Enable();
    }

    void OnDisable()
    {
        pauseAction.action.Disable();
    }

    void OnPause(InputAction.CallbackContext context)
    {
        if(paused)
            {
                resume();
            }
            else
            {
                pause();
            }
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
