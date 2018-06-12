using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagerMenu : MonoBehaviour
{

    public Transform menu ;
     //public Transform   options,highScoreMenu;
    public GameObject Options;
    public GameObject Buttons;
    public GameObject QuitPanel;



    public Slider audiosl;
    public Slider graphicsl;

 


    public void Start()
    {
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
    }
    public void LoadScene(string name) //when we click to the button we put it the scene when we wanna load
    {
        SceneManager.LoadScene(name);
    }

  
    public void QuitGameYes()
    {
       Application.Quit();
    }
    public void QuitGameNo()
    {
        QuitPanel.SetActive(false);
        Buttons.SetActive(true);

    }




    public void Option(bool a)
    {
        if (a == true)
        {
            Options.SetActive(a);
            Buttons.SetActive(!a);
            Animation Opt = Options.GetComponent<Animation>();
            Opt.Play("OptionEnter");



        } if (a == false)
        {
            Animation d = Buttons.GetComponent<Animation>();

            d.Play("mainbuttonenter");
            Options.SetActive(false);
        }
    }

    public void Quit(bool a)
    {
        if (a == true)
        {
            QuitPanel.SetActive(a);
            Buttons.SetActive(!a);
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
            Buttons.SetActive(true);
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
