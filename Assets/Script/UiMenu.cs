using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UiMenu : MonoBehaviour
{
    public TextMeshProUGUI musicValue;
    public AudioMixer musicMixer;
    public TextMeshProUGUI soundsValue;
    public AudioMixer soundsMixer;
    private Animator animator;
    private int _window = 0;
    private bool accpet = false;
    [SerializeField] private string screenname;

    [Header("Score")]
    public TMP_Text scoreText;

    [Header("Timer")]
    public TMP_Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _window == 1 && accpet == true)
        {
            animator.SetTrigger("HidePause");
            _window = 0;
            accpet = false;
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _window == 0 && accpet == false)
        {
            animator.SetTrigger("ShowPause");
            _window = 1;
            accpet = true;
            Time.timeScale = 0;
        }
        else
        {
            Update_Timer();
            Update_Score();
        }

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

    private void Update_Timer()
    {
        if (timerText == null)
            return;

        int currentTime = (int)GameManager_Shabu.instance.GetCurrentTimer();

        int munite = (int)currentTime / 60;
        int sec = (int)currentTime % 60;
        timerText.text = string.Format("{0:00}:{1:00}", munite, sec);
    }

    private void Update_Score()
    {
        if (scoreText == null)
            return;

        int currentscore = (int)GameManager_Shabu.instance.GetCurrentScore();

        scoreText.text = currentscore.ToString();
    }

    public void Quit()
    {
        /*if(screenname == "IntroMenu")
            SceneManager.UnloadSceneAsync("OpenWorld");
        else
            SceneManager.LoadScene(screenname);*/
        Time.timeScale = 1;
        SceneManager.LoadScene(screenname);
    }

    public bool isPause()
    {
        return accpet;
    }
}
