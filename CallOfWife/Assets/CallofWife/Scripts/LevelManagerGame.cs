using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerGame : MonoBehaviour
{
    public static LevelManagerGame instance = null;  
    private AudioSource soundSource;
    public AudioClip deathSound;
    public GameObject Options;
    public GameObject QuitPanel;

    public GameObject pauseButton, pausePanel, menuButton,panelGameOver,YouWinPanel;

    public Slider audiosl;
    public Slider graphicsl;


    public int wallControl;

    public GameObject wall;

    void Awake()
    {
        //SINGLETON 
        if (instance == null)  //check and see dowe have a gm yet, if not set it
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        soundSource = GetComponent<AudioSource>();

    }

    public void Start()
    {
        wallControl = 0;

        OnUnPause();


        QualitySettings.SetQualityLevel((int)PlayerPrefs.GetFloat("Quality"));
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        int qualityLevel = QualitySettings.GetQualityLevel();
        audiosl.value = AudioListener.volume;
        graphicsl.value = qualityLevel;
    }

    void Update()

    {

        AudioListener.volume = audiosl.value;
        QualitySettings.SetQualityLevel((int)graphicsl.value);

        if (wallControl == 4)
        {
            DestroyObject(wall);
        }


        if (Input.GetButtonDown("Cancel"))

        {
            OnPause();
        }
    }
    public void OnPause()
    {
        Time.timeScale = 0;

        Cursor.visible = true;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void OnUnPause()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }
    public void goMenu(string name)
    {
        SceneManager.LoadScene(name);


    }
    public void GameOver()
    {
        panelGameOver.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 0;


    }
    public void YouWin()
    {
        YouWinPanel.SetActive(true);
        Cursor.visible = true;
        Time.timeScale = 1;


    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void DeathSound()
    {
        soundSource.PlayOneShot(deathSound);

    }



    public void QuitGameYes()
    {
        Application.Quit();
    }
    public void QuitGameNo()
    {
        QuitPanel.SetActive(false);
        pausePanel.SetActive(true);

    }


    public void Option(bool a)
    {
        if (a == true)
        {
            Options.SetActive(a);
            pausePanel.SetActive(!a);
    


        } if (a == false)
        {
            Options.SetActive(false);
        }
    }

    public void Quit(bool a)
    {
        if (a == true)
        {
            QuitPanel.SetActive(a);
            pausePanel.SetActive(!a);
            Animation q = QuitPanel.GetComponent<Animation>();
            q.Play("EnterQuit");
        }
        else
        {
            QuitPanel.SetActive(a);
        }

    }

    public void Exit(bool a)
    {
        if (a == false)
        {
            Option(false);
            pausePanel.SetActive(true);
            QuitPanel.SetActive(false);
            Options.SetActive(false);

        }
        if (a == true)
        {
            Application.Quit();
        }
    }
    public void saveSettings()
    {
        PlayerPrefs.SetFloat("Quality", QualitySettings.GetQualityLevel());
        PlayerPrefs.SetFloat("Volume", AudioListener.volume);
    }
    public void FullScreen(bool a)
    {
        if (Screen.fullScreen == a)
        {
            Screen.fullScreen = !a;
        }
        else
        {
            Screen.fullScreen = a;
        }
    }

}
