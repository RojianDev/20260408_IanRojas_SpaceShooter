using System;
using System.Drawing;
using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
//using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    public static Global instance {get; private set;}
    public int score = 0;
    public int lifes = 3;
    int maxLifes = 3;
    public float specialBar = 0f;
  
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        lifes = maxLifes;  
    }

    public void AddScore(int value)
    {
        score += value;
        //print(score);
        Debug.Log("Score actual: " + score);
    }

    public void AddLive(int amount)
    {
        lifes += amount;
        if (lifes>maxLifes)
        {
            lifes = maxLifes;
        }
    }

    public void LoseLive(int amount)
    {
        lifes -= amount;
        if (lifes <= 0)
        {
            OnlivesDepleted();
        }
    }

    public void AddSpecial(float amount)
    {
        specialBar += amount;
    }

    public void ResetSpecial()
    {
        specialBar = 0f;
    }

    public void Reset()
    {
        specialBar = 0f;
        lifes = maxLifes;
        score = 0;
        Time.timeScale = 1;

    }

    void OnlivesDepleted()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnDestroy()
    {
        if(instance == this) instance = null;
    }

}
