using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    private Animator _coinCollect;
    [SerializeField]
    private AudioSource _coinCollected;
    [SerializeField]
    private Collider _coinCollider;

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.CoinUpdate();
            }
            _coinCollect = GetComponent<Animator>();
            _coinCollect.SetTrigger("Collected");
            _coinCollected.Play();
            _coinCollider.enabled = false;
            Destroy(this.gameObject,1f);
        }
    }
}
