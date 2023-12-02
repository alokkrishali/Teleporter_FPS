using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
    public List<GameObject> screens; //loading, menu, clear, failed
    [SerializeField] Image loadingBar;
    [SerializeField] Button nextBtn;
    [SerializeField] TextMeshProUGUI scoreValue, helthValue, PowerUpsValue, LevelCompleteScore, LevelCompletePowerUps;

    [SerializeField] List<GameObject> loadingScreen;
    public static UiManager instance;
    bool IsLoading = false;
    float fillBarValue = 0;
    [SerializeField] GameObject joystick, LeftSideBtns;
    [SerializeField] bool IsDevMode = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (!IsDevMode)
        {
            screens[0].SetActive(true);
            IsLoading = true;
            fillBarValue = 0;
        }
        else
            screens[4].SetActive(true);

#if UNITY_ANDROID
            joystick.SetActive(true);
            LeftSideBtns.SetActive(true);
#else
            joystick.SetActive(false);
            LeftSideBtns.SetActive(false);
#endif
    }

    public void OnReset()
    {
        LevelController.instance.SetLevel(0);
    }
    public void OnPlayClick()
    {
        LevelController.instance.SetLevel(LevelController.instance.GetLevel());
        LevelController.instance.ShowLevel();
        OnGamePlay();
    }

    public void UpdatedScore()
    {
        scoreValue.text = "Score: "+ScoreManager.instance.GetScore();
    }
    public void UpdatedPowerUp()
    {
        PowerUpsValue.text = ScoreManager.instance.GetPowerUps().ToString();
    }


    public void UpdatedHealth()
    {
        helthValue.text = "Health: "+ HelthManager.instance.GetHealth();
    }
    public void OnRePlayClick()
    {
        LevelController.instance.SetLevel(LevelController.instance.GetLevel());
        LevelController.instance.ShowLevel();
        OnGamePlay();
    }

    public void OnExitClick()
    {
        Application.Quit();
    }
    public void OnNextClick()
    {
        LevelController.instance.SetLevel(LevelController.instance.GetLevel()+1);
        LevelController.instance.ShowLevel();
        ScoreManager.instance.ResetPowerUps();
        ScoreManager.instance.ResetScore();
        OnGamePlay();
    }

    public void OnMenuClick()
    {
        ShowMenu();
    }

    
    public void ShowMenu()
    {
        DisableAllScreen();
        screens[1].SetActive(true);
    }

    public void OnGamePlay()
    {
        DisableAllScreen();
        screens[4].SetActive(true);
    }
    public void ShowLevelClear()
    {
        if (LevelController.instance.GetLevel() == 2)
            nextBtn.interactable = false;
        else
            nextBtn.interactable = true;
        DisableAllScreen();
        LevelCompleteScore.text = ScoreManager.instance.GetScore().ToString();
        LevelCompletePowerUps.text = ScoreManager.instance.GetPowerUps().ToString();
        screens[2].SetActive(true);
    }

    public void ShowLevelFailed()
    {
        DisableAllScreen();
        screens[3].SetActive(true);
    }
    private void DisableAllScreen()
    {
        for(int i=0;i< screens.Count;i++)
        {
            screens[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (IsLoading)
        {
            fillBarValue += .125f*Time.deltaTime;
            loadingBar.fillAmount = fillBarValue;
            if (fillBarValue <= .25f)
                loadingScreen[0].SetActive(true);
            else if (fillBarValue <= .65f && fillBarValue >= .25f)
            {
                loadingScreen[0].SetActive(false);
                loadingScreen[1].SetActive(true);
            }
            else
            {
                loadingScreen[1].SetActive(false);
                loadingScreen[2].SetActive(true);
            }
            if (fillBarValue >= 1)
                    {
                        DisableAllScreen();
                        screens[1].SetActive(true);
                        IsLoading = false;
                    }
        }
    }
}
