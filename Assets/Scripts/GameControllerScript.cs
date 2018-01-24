using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public GameObject m_character, m_characterPrefab, m_pipeSpawner, m_retryText, m_scoreText;

    bool m_gameOver = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //check for restart
		if (Input.GetButtonDown("Jump") && m_gameOver)
        {
            Restart();
        }
	}

    //called when the game is ended
    public void Stop()
    {
        //delete old objects
        Destroy(m_character);

        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe Marker"))
        {
            Destroy(pipe);
        }

        //turn off spawner
        m_pipeSpawner.SetActive(false);
        m_retryText.SetActive(true);
        m_gameOver = true;
    }

    void Restart()
    {
        //recreate game 
        //could also just restart the scene but this is simpler
        m_gameOver = false;
        m_pipeSpawner.SetActive(true);
        m_character = Instantiate(m_characterPrefab) as GameObject;
        m_character.GetComponent<CharacterScript>().m_gameController = gameObject;
        m_retryText.SetActive(false);
        m_scoreText.GetComponent<ScoreScript>().Reset();
    }
}
