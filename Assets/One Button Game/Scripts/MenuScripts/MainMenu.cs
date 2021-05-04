using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public string loadScene = "Game";
    public Slider musicSlider;
    public Slider sfxSlider;
    public AudioMixer mixer;
    public Dropdown qualityDropdown;
    public Toggle fullscreenToggle;
    public Resolution[] resolutions;
    public Dropdown resolusion;

    public void Awake()
    {
        // Load all the setting we saved
        LoadPlayerPrefs();
    }

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        resolusion.ClearOptions();
        List<string> options = new List<string>();

        int currentRseolutionIndex = 0;

        // Loop through every resolution
        for (int i = 0; i < resolutions.Length; i++)
        {

            // Build a string for displaying the resolution
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                // We have found the current screen resolution, save that number
                currentRseolutionIndex = i;
            }
        }
        // Set up our dropdown
        resolusion.AddOptions(options);
        resolusion.value = currentRseolutionIndex;
        resolusion.RefreshShownValue();

        // Set up full screen
        if (!PlayerPrefs.HasKey("fullscreen"))
        {
            PlayerPrefs.SetInt("fullscreen", 0);
            Screen.fullScreen = false;
        }
        else
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                Screen.fullScreen = false;
            }
            else
            {
                Screen.fullScreen = true;
            }
        }

        // Set up gameplay quality
        if (!PlayerPrefs.HasKey("quality"))
        {
            PlayerPrefs.SetInt("quality", 5);
            QualitySettings.SetQualityLevel(5);
        }
        else
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality"));
        }

        // Save all the data in playerprefs
        PlayerPrefs.Save();
    }

    // Load the game scene
    public void StartGame()
    {
        SceneManager.LoadScene(loadScene);
    }

    // Set fullscreen or not
    public void SetFullScreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }

    // Change the quallity of the game
    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    // Set up the music vol var slider
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat("MusicVol", value);
    }

    // Set up the sound FX val var slider
    public void SetSFXVolume(float value)
    {
        mixer.SetFloat("SFXVol", value);
    }

    // Quit the game in unityeditor and build
    public void QuitGame()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }

    // Save all the change we made in options menu
    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());

        if (fullscreenToggle.isOn)
        {
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("fullscreen", 0);
        }

        float musicVol;
        if (mixer.GetFloat("MusicVol", out musicVol))
        {
            PlayerPrefs.SetFloat("MusicVol", musicVol);
        }

        float SFXVol;
        if (mixer.GetFloat("SFXVol", out SFXVol))
        {
            PlayerPrefs.SetFloat("SFXVol", SFXVol);
        }

        PlayerPrefs.Save();
    }

    // Load all the data var open the menu
    public void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("quality"))
        {
            int quality = PlayerPrefs.GetInt("quality");
            qualityDropdown.value = quality;
            if (QualitySettings.GetQualityLevel() != quality)
            {
                ChangeQuality(quality);
            }
        }

        if (PlayerPrefs.HasKey("fullscreen"))
        {
            if (PlayerPrefs.GetInt("fullscreen") == 0)
            {
                fullscreenToggle.isOn = false;
            }
            else
            {
                fullscreenToggle.isOn = true;
            }
        }
        if (PlayerPrefs.HasKey("MusicVol"))
        {
            float musicVol = PlayerPrefs.GetFloat("MusicVol");
            musicSlider.value = musicVol;
            mixer.SetFloat("MusicVol", musicVol);
        }

        if (PlayerPrefs.HasKey("SFXVol"))
        {
            float SFXVol = PlayerPrefs.GetFloat("SFXVol");
            sfxSlider.value = SFXVol;
            mixer.SetFloat("SFXVol", SFXVol);
        }
    }

    // Set up the resolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, false);
    }
}
