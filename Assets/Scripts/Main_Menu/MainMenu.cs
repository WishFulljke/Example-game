using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _start;
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private GameObject _volume;
    private BackGroundMusic _music;
    private bool _isMenuActive = false;
    private bool _isVolumeActive = false;

    void Start()
    {
        _music = GameObject.Find("BackGround_Music").GetComponent<BackGroundMusic>();

        if (_music == null)
        {
            Debug.Log("Music is NULL");
        }

        _music.MenuBackGround();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            SceneManager.LoadScene(1);            
            _music.GameBackGround();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && _isMenuActive == false)
        {
            Menu();
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isMenuActive == true && _isVolumeActive == false)
        {
            ExitMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isMenuActive == true && _isVolumeActive == true)
        {
            ExitVolume();
        }
    }

    void Menu()
    {      
        _menu.SetActive(true);
        _start.SetActive(false);
        _isMenuActive = true;
    }
    void ExitMenu()
    {
        _menu.SetActive(false);
        _volume.SetActive(false);
        _start.SetActive(true);
        _isMenuActive = false;
    }

    void ExitVolume()
    {
        _volume.SetActive(false);
        _menu.SetActive(true);
        _isVolumeActive = false;
    }

    public void VolumeSetup()
    {
        _volume.SetActive(true);
        _menu.SetActive(false);
        _isVolumeActive = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);       
    }
      
    
}
