using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText, _livesText;
    [SerializeField]
    private GameObject _text;    
    


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);            
        }
    }
      

    public void UpdateCoinDisplay(int coinCollected)
    {
        _scoreText.text = "Score: " + coinCollected.ToString();
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();        
    }

    public void GameOver()
    {
        StartCoroutine(RestartRoutine());
    }

    IEnumerator RestartRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _text.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            _text.SetActive(false);
        }                
    }
}
