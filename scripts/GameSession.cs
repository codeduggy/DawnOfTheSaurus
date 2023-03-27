using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
       livesText.text = playerLives.ToString();     
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            RemoveLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    void RemoveLife()
{
    playerLives--;
    StartCoroutine(LoadSceneWithDelay());
    livesText.text = playerLives.ToString();
}

IEnumerator LoadSceneWithDelay()
{
    yield return new WaitForSeconds(2f);
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
}
    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
