using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = GameObject.Find("Player").GetComponent<Player>();

            if (player != null)
            {
                player.Damage();                
            }

            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
            }

            StartCoroutine(PositionRoutine(other));            

            if (cc != null)
            {
                StartCoroutine(CCEnabledRoutine(cc));
            }
        }
    }

    IEnumerator PositionRoutine(Collider other)
    {
        yield return new WaitForSeconds(3f);
        other.transform.position = _respawnPoint.transform.position;
    }

    IEnumerator CCEnabledRoutine(CharacterController controller)
    {
        yield return new WaitForSeconds(4.5f);
        controller.enabled = true;
    }
}
