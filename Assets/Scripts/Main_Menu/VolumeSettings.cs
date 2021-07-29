using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSettings : MonoBehaviour
{
    [SerializeField]
    private AudioSource _menu;
    [SerializeField]
    private Slider _slider;
        

    private void Start()
    {
        Load();
    }

    // Update is called once per frame
    void Update()
    {
        _menu.volume = _slider.value;
        PlayerPrefs.SetFloat("Slider", _slider.value);

        if (_menu.volume != _slider.value)
        {
            Load();
        }        
    }

    void Load()
    {
        _slider.value = PlayerPrefs.GetFloat("Slider");
        _menu.volume = _slider.value;        
    }
}
