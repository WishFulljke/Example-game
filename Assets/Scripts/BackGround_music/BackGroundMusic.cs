using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundMusic : MonoBehaviour
{
    [SerializeField]
    private AudioSource _music;
    [SerializeField]
    private AudioClip _clip1, _clip2;
    [SerializeField]
    private GameObject _audioManager;
    
    public void MenuBackGround()
    {
        _music.clip = _clip1;
        _music.Play();
    }

    public void GameBackGround()
    {
        _music.clip = _clip2;
        _music.Play();
    }   
}
