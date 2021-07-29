using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{    
    [SerializeField]
    private static DontDestroy _background;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (_background == null)
        {
            _background = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }    
}
