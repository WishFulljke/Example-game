using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Transform _targetA, _targetB, _targetC, _targetD;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _verticalTrap;
    private bool _switching = false, _verticalSwitching = false;

    // Update is called once per frame
    void Update()
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

        if (_verticalSwitching == false)
        {
            _verticalTrap.transform.position = Vector3.MoveTowards(_verticalTrap.transform.position, _targetD.position, _speed * Time.deltaTime);

            if (_verticalTrap.transform.position == _targetD.position)
            {
                _verticalSwitching = true;
            }
        }

        if (_verticalSwitching == true)
        {
            _verticalTrap.transform.position = Vector3.MoveTowards(_verticalTrap.transform.position, _targetC.position, _speed * Time.deltaTime);

            if (_verticalTrap.transform.position == _targetC.position)
            {
                _verticalSwitching = false;
            }
        }
    }    
}
