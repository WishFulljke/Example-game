using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    private BackGroundMusic _play;

    void Start()
    {
        _play = GameObject.Find("BackGround_Music").GetComponent<BackGroundMusic>();
    }

    // Update is called once per frame
    void Update()
    {
        _button.onClick.AddListener(() => _play.GameBackGround());
    }
}
