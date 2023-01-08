using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float GlobalTime = 0;
    float difficultyTimer = 10;
    float moneyCount = 0;

    public EnemyManager enemyManager;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("GameManager instance not found");

            return instance;
        }
    }
    void Awake()
    {
        if (instance)
            Destroy(instance.gameObject);
        instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        GlobalTime += Time.deltaTime;
        difficultyTimer -= Time.deltaTime;
        if(difficultyTimer <= 0)
        {
            DifficultyChange();
            difficultyTimer = 10;
        }
    }

    void DifficultyChange()
    {
        enemyManager.DifficultyChange();
    }

    public float GetMoney()
    {
        return moneyCount;
    }

    public void AddMoney(float amount)
    {
        moneyCount += amount;
    }

    public void GameOver()
    {
        SetTimeScale(0);
        UIManager.Instance.GameOver();
    }

    public void Win()
    {
        SetTimeScale(0);
        UIManager.Instance.Win();
    }

    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void BackToMenu()
    {
        ResetVars();
        SceneManager.LoadScene("MainMenu");
    }

    public void SetTimeScale(int a)
    {
        Time.timeScale = a;
    }

    private void ResetVars()
    {
        GlobalTime = 0;
        difficultyTimer = 10;
        moneyCount = 0;
    }
}
