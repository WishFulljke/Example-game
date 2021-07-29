using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelEnd : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelCompleteText;
    [SerializeField]
    private Collider _levelEndCollider;
    [SerializeField]
    private Renderer _alienSprite;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {            
            _alienSprite.enabled = false;
            _levelEndCollider.enabled = false;            
            LevelComplete();
            Player player = other.GetComponent<Player>();
            player.VictoryAnim();
        }
    }

    public void LevelComplete()
    {       
         StartCoroutine(LevelCompleteRoutine());      
    }
    
    IEnumerator LevelCompleteRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _levelCompleteText.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _levelCompleteText.SetActive(false);
        }        
    }
}
