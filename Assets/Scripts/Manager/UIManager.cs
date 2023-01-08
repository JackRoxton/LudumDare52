using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Button PlayButton, QuitButton;

    [SerializeField]
    GameObject GamePanel, MainMenuPanel, PauseMenuPanel, GameOverPanel, TutoPanel;

    [SerializeField]
    Button ResumeButton, pMenuButton;

    [SerializeField]
    Button goMenuButton;

    [SerializeField]
    TMP_Text MoneyText, goText;

    bool mainMenu = true;
    bool showTuto = true;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("UIManager instance not found");

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

    private void Start()
    {
        PlayButton.onClick.AddListener(Play);
        QuitButton.onClick.AddListener(Quit);

        ResumeButton.onClick.AddListener(Resume);
        pMenuButton.onClick.AddListener(BackToMenu);

        goMenuButton.onClick.AddListener(BackToMenu);

        GamePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        PauseMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        TutoPanel.SetActive(false);
        GameManager.Instance.SetTimeScale(0);
    }

    private void Update()
    {
        MoneyText.text = GameManager.Instance.GetMoney().ToString();

        if(!mainMenu && showTuto)
        {
            if (Input.anyKeyDown)
            {
                Tuto();
            }
        }
        else if (!mainMenu && !showTuto)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }
    }

    public void Play()
    {
        MoneyText.text = 0.ToString();
        mainMenu = false;

        GamePanel.SetActive(true);
        MainMenuPanel.SetActive(false);
        PauseMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);

        if (showTuto)
        {
            TutoPanel.SetActive(true);
            //GameManager.Instance.SetTimeScale(0);
        }
        else
        {
            TutoPanel.SetActive(false);
            GameManager.Instance.SetTimeScale(1);
        }

        GameManager.Instance.Play();
    }

    void BackToMenu()
    {
        mainMenu = true;

        GamePanel.SetActive(false);
        MainMenuPanel.SetActive(true);
        PauseMenuPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        TutoPanel.SetActive(false);
        GameManager.Instance.SetTimeScale(0);

        GameManager.Instance.SetTimeScale(0);
        GameManager.Instance.BackToMenu();
    }

    void Tuto()
    {
        showTuto = false;
        TutoPanel.SetActive(false);
        GameManager.Instance.SetTimeScale(1);
    }

    void Pause()
    {
        PauseMenuPanel.SetActive(true);
        GameManager.Instance.SetTimeScale(0); 
    }

    void Resume()
    {
        PauseMenuPanel.SetActive(false);
        GameManager.Instance.SetTimeScale(1);
    }

    public void Win()
    {
        GameOverPanel.SetActive(true);
        goText.text = "Congratulations you successfully defended your farm !";
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        goText.text = "Sadly, the enemies managed to destroy your farm. Try again !";
    }

    void Quit()
    {
        Application.Quit();
    }
}
