using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uiManagerScript : MonoBehaviour
{

    public static bool isGamePaused = false; //to access to other scripts - soundmanager
    public static bool isUpgradeOpen = false;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Text upgradeMenuOpenText;
    // [SerializeField] private Text cellText;
    void Start()
    {

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) //pause check
        {

            if (isGamePaused)
            {
                resume();
            }
            else
            {
                pause();
            }

        }

        if (Input.GetKeyDown(KeyCode.U)) //upgarde menu check
        {
            if (isUpgradeOpen)
            {
                closeUpgradeMenu();
            }
            else
            {
                openUpgradeMenu();
            }
        }
    }

    void closeUpgradeMenu()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        isUpgradeOpen = false;
        upgradeMenuOpenText.gameObject.SetActive(true);
        // cellText.gameObject.SetActive(true);
    }

    void openUpgradeMenu()
    {
        upgradeMenu.SetActive(true);
        Time.timeScale = 0f;
        isUpgradeOpen = true;
        upgradeMenuOpenText.gameObject.SetActive(false);
        // cellText.gameObject.SetActive(false);
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;

    }

    void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;

    }
    public void loadMenu()
    {

        //Debug.Log("LOADING MENU");
        //use scene manager to load the start screen
        //SceneManager.LoadScene("Menu");
        //Time.timeScale = 1f;          //reactivating the time
    }

    public void quit()
    {
        //Debug.Log("QUITTING");
        //quit the game
        //Application.Quit();
    }

    void toggleUpgradeMenu()
    {
        upgradeMenu.SetActive(!upgradeMenu.activeSelf);
    }
}
