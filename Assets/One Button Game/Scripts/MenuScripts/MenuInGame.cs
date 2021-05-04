using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuGameObject;
    [SerializeField] GameObject winAndLoseGameObject;
    [SerializeField] GameObject pointGameObject;
    [SerializeField] GameObject heartGameObject;
    [SerializeField] GameObject loseMenu;
    [SerializeField] GameObject winMenu;
    EnterBottomBox enterBottomBox;
    Spawn spawn;
    WinAndLose winAndLose;
    public string loadScene = "MainMenu";
    bool active = false;

    private void Start()
    {
        winAndLose = winAndLoseGameObject.GetComponent<WinAndLose>();
        enterBottomBox = pointGameObject.GetComponent<EnterBottomBox>();
        spawn = heartGameObject.GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        // If none of the menu is on then open pausemenu
        if(pauseMenuGameObject.activeSelf == false && winMenu.activeSelf == false && loseMenu.activeSelf == false && Input.GetKeyDown(KeyCode.Escape))
        {
            active = true; 
        }

        // If pausemenu is on and want to exit without button
        if(pauseMenuGameObject.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            active = false;
        }
        pauseMenuGameObject.SetActive(active);
    }

    public void SetActive()
    {
        // Function for exit the pause menu
        active = false;
        Time.timeScale = 1f;
        pauseMenuGameObject.SetActive(active);
    }

    public void BackToMenu()
    {
        // Function for back to main menu
        SceneManager.LoadScene(loadScene);
    }

    public void ReStart()
    {
        // When we lose then restart the game
        spawn.heart = 10;
        enterBottomBox.point = 0;
        winAndLose.lose = false;
        loseMenu.SetActive(false);
    }

    public void StartLv1()
    {
        // Go to lv1 game
        winAndLose.lv1 = true;
        winAndLose.lv2 = false;
        winAndLose.lv3 = false;
        spawn.heart = 10;
        enterBottomBox.point = 0;
        winAndLose.lose = false;
        winAndLose.win = false;
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    public void StartLv2()
    {
        // Go to lv2 game
        winAndLose.lv1 = false;
        winAndLose.lv2 = true;
        winAndLose.lv3 = false;
        spawn.heart = 10;
        enterBottomBox.point = 0;
        winAndLose.lose = false;
        winAndLose.win = false;
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }
    
    public void StartLv3()
    {
        // Go to lv3 game
        winAndLose.lv1 = false;
        winAndLose.lv2 = false;
        winAndLose.lv3 = true;
        spawn.heart = 10;
        enterBottomBox.point = 0;
        winAndLose.lose = false;
        winAndLose.win = false;
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
    }
}
