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
    [SerializeField] TextMeshProUGUI scoreValue, helthValue;

    public static UiManager instance;
    bool IsLoading = false;
    float fillBarValue = 0;
    [SerializeField] GameObject joystick;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        screens[0].SetActive(true);
        IsLoading = true;
        fillBarValue = 0;
#if UNITY_ANDROID
            joystick.SetActive(true);
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

    public void UpdateScore()
    {

    }

    public void UpdateHelth()
    {

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
        if (LevelController.instance.GetLevel() == 3)
            nextBtn.interactable = false;
        else
            nextBtn.interactable = true;
        DisableAllScreen();
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
            fillBarValue += Time.deltaTime*.35f;
            loadingBar.fillAmount = fillBarValue;
            if (fillBarValue >= 1)
            {
                Debug.Log("Value - "+ fillBarValue);
                DisableAllScreen();
                screens[1].SetActive(true);
                IsLoading = false;
            }
        }
    }
}
