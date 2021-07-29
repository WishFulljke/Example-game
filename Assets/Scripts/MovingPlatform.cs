using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB, _targetC, _targetD;
    private float _speed = 3.0f;
    private bool _switching = false;
    private bool _switchingUpPlat = false;
    [SerializeField]
    private GameObject _upPlatform;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
            if (transform.position == _targetB.position)
            {
                _switching = true;
            }
            
        }
        
        
        if (_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
            if (transform.position == _targetA.position)
            {
                _switching = false;
            }
            
        }

        if (_switchingUpPlat == false)
        {
            _upPlatform.transform.position = Vector3.MoveTowards(_upPlatform.transform.position, _targetD.position, _speed * Time.deltaTime);

            if (_upPlatform.transform.position == _targetD.position)
            {
                _switchingUpPlat = true;
            }
        }

        if (_switchingUpPlat == true)
        {
            _upPlatform.transform.position = Vector3.MoveTowards(_upPlatform.transform.position, _targetC.position, _speed * Time.deltaTime);

            if (_upPlatform.transform.position == _targetC.position)
            {
                _switchingUpPlat = false;
            }
        }
    }
       
}
