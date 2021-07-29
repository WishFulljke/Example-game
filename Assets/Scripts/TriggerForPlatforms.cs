using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForPlatforms : MonoBehaviour
{
    private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.PlatformCollision();
            }
        }
    }
}
