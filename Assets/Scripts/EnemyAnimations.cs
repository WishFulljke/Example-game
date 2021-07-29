using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField]
    private Animator _enemy;
    

    void FixedUpdate()
    {
        _enemy.SetBool("isIdle", true);
        _enemy.SetBool("isRunning", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player sound = other.GetComponent<Player>();
            sound.LandedOnTheEnemySound();
            _enemy.SetTrigger("OnEnemyDeath");
            Destroy(this.gameObject, 1f);
        }
    }
}
