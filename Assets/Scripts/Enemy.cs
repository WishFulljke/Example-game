using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA, _targetB;
    private float _speed = 2.0f;
    private bool _switching = false;
    
    
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


    }   
}
