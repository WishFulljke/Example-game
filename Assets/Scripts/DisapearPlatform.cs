using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearPlatform : MonoBehaviour
{
    [SerializeField] private GameObject _platform, _platform2;
    [SerializeField] private bool _isStarted = false;

    private void Start()
    {
        _isStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStarted == true)
        {
            PlatfromFleaker();
        }                    
    }

    void PlatfromFleaker()
    {
        _isStarted = false;
        StartCoroutine(Disapear());
        StartCoroutine(SecondPlatformDisapear());
    }

    IEnumerator SecondPlatformDisapear()
    {
        while (1 < 2)
        {
            _platform2.SetActive(false);
            yield return new WaitForSeconds(4f);
            _platform2.SetActive(true);
            yield return new WaitForSeconds(4f);
        }
    }

    IEnumerator Disapear()
    {        
        while (1 < 2)
        {            
            _platform.SetActive(false);
            yield return new WaitForSeconds(5f);
            _platform.SetActive(true);
            yield return new WaitForSeconds(5f);
        }        
    }
}
