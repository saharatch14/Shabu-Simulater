using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public string loaderScene;

    public int gamemode = 0;
    public TextMeshProUGUI musicValue;
    public AudioMixer musicMixer;
    public TextMeshProUGUI soundsValue;
    public AudioMixer soundsMixer;
    public Button loadButton;
    public Sprite[] pic;
    public GameObject fullimage;

    private Animator animator;
    private int _window = 0;
    private int _windowUnlock = 0;

    public void Start()
    {
        Time.timeScale = 1;
        animator = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("ScoreAllMeat") <= 0)
        {
            loadButton.interactable = false;
        }
        else if (PlayerPrefs.GetInt("ScoreAllMeat") > 0)
        {
            loadButton.interactable = true;
        }
#if UNITY_EDITOR
        Debug.Log(PlayerPrefs.GetInt("ScoreAllMeat"));
        Debug.Log($"||ScoreAllMeat: {PlayerPrefs.GetInt("ScoreRingToss")} || EatMeat: {PlayerPrefs.GetInt("ScoreKnockOut")}");
#endif
        //FinalscoreText.text = PlayerPrefs.GetInt("FinalScore").ToString();
        StaticData.valueToKeep = 0;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _window == 1)
        {
            animator.SetTrigger("HideOptions");
            _window = 0;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && _windowUnlock == 1)
        {
            animator.SetTrigger("HideUnlock");
            _windowUnlock = 0;
        }
    }

    public void NewGame()
    {
        Load();
    }

    public void Load()
    {
        if(gamemode == 0)
            StaticData.valueToKeep = 0;
        else if(gamemode == 1)
            StaticData.valueToKeep = 1;

        SceneManager.LoadScene(loaderScene, LoadSceneMode.Additive);
    }

    public void ShowUnlockOptions()
    {
        animator.SetTrigger("ShowUnlock");
        _windowUnlock = 1;
    }

    public void HideUnlockOptions()
    {
        animator.SetTrigger("HideUnlock");
        _windowUnlock = 0;
    }

    public void ShowOptions()
     {
         animator.SetTrigger("ShowOptions");
        _window = 1;
     }

    public void HideOptions()
    {
        animator.SetTrigger("HideOptions");
        _window = 0;
    }

    public void ZoomImage(int code)
    {
        switch (code)
        {
            case 0:
                if (PlayerPrefs.GetInt("ScoreAllMeat") >= 500)
                {
                    fullimage.SetActive(true);
                    fullimage.GetComponentInChildren<Image>().sprite = pic[code];
                }
                else
                {

                }
                break;

            case 1:
                if (PlayerPrefs.GetInt("ScoreAllMeat") >= 1500)
                {
                    fullimage.SetActive(true);
                    fullimage.GetComponentInChildren<Image>().sprite = pic[code];
                }
                else
                {

                }
                break;

            case 2:
                if (PlayerPrefs.GetInt("EatMeat") >= 50)
                {
                    fullimage.SetActive(true);
                    fullimage.GetComponentInChildren<Image>().sprite = pic[code];
                }
                else
                {

                }
                break;

            case 3:
                if (PlayerPrefs.GetInt("EatMeat") > 100)
                {
                    fullimage.SetActive(true);
                    fullimage.GetComponentInChildren<Image>().sprite = pic[code];
                }
                else
                {

                }
                break;
        }
    }

    public void ResetScore()
    {
        PlayerDataManager.inter.Reset();
        loadButton.interactable = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnModeChanged(int value)
    {
        gamemode = value;
    }

    public void OnMusicChanged(float value)
    {
        musicValue.SetText(value + "%");
        musicMixer.SetFloat("volume", -50 + value / 2);
    }
    
    public void OnSoundsChanged(float value)
    {
        soundsValue.SetText(value + "%");
        soundsMixer.SetFloat("volume", -50 + value / 2);
    }
}
