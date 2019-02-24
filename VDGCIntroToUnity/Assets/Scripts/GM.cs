using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    public int lives = 3;
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject player;
    public GameObject deathParticles;
    public string levelToLoad;
    public static GM instance = null;

    private GameObject clonePlayer;
    

	// Use this for initialization
	private void Awake () {
		if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        Setup();
	}
	
    // Load objects for game (player)
    public void Setup()
    {
        clonePlayer = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
    }

    // Method that checks for game over
    private void CheckGameOver()
    {
        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }
    }

    // Method to reset level if game lost
    private void Reset()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to switch to next level
    private void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelToLoad);
    }

    // Method to keep track of lives lost
    public void LoseLife()
    {
        
        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticles, clonePlayer.transform.position, Quaternion.identity);
        Destroy(clonePlayer);
        Invoke("SetupPlayer", resetDelay);
        CheckGameOver();
    
    }

    // Reset player if life is lost
    private void SetupPlayer()
    {
        clonePlayer = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
    }
}
