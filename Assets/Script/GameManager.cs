using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentEnergy;
    [SerializeField] private int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject spawnEnemy;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameObject winMenu;

    void Start()
    {
        currentEnergy = 0;
        boss.SetActive(false);
        UpdateEnergyBar();
        MainMenu();
        audioManager.StopAudioGame();
    }

    public void AddEnergy()
    {
        if (bossCalled)
        {  
            return; 
        }

        currentEnergy += 1;
        UpdateEnergyBar();
        if (currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }

    private void CallBoss()
    {
            bossCalled = true;
            boss.SetActive(true);
            spawnEnemy.SetActive(false);
            gameUI.SetActive(false);
            audioManager.PlayDbossAudio();
    }
    private void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverMenu .SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameOverMenu()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        winMenu.SetActive(false);
    }

    public void PauseMenu()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(true);
        winMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void RemuseGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudio();
    }

    public void WinMenu()
    {
        Debug.Log("HÀM WINMENU() ĐÃ ĐƯỢỢC GỌI THÀNH CÔNG!");
        mainMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(true);

        Debug.Log("Trạng thái active của winMenu là: " + winMenu.activeSelf);
        Debug.Log("Trạng thái active trong Hierarchy của winMenu là: " + winMenu.activeInHierarchy);

        Time.timeScale = 0f;
    }
}
