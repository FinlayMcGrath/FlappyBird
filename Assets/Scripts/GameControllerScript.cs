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
		if (Input.GetButtonDown("Jump") && m_gameOver)
        {
            Restart();
        }
	}

    public void Stop()
    {
        Destroy(m_character);
        m_pipeSpawner.SetActive(false);
        foreach (GameObject pipe in GameObject.FindGameObjectsWithTag("Pipe Marker"))
        {
            Destroy(pipe);
        }
        m_retryText.SetActive(true);
        m_gameOver = true;
    }

    void Restart()
    {
        m_gameOver = false;
        m_pipeSpawner.SetActive(true);
        m_character = Instantiate(m_characterPrefab) as GameObject;
        m_character.GetComponent<CharacterScript>().m_gameController = gameObject;
        m_retryText.SetActive(false);
        m_scoreText.GetComponent<ScoreScript>().m_score = 0;
    }
}
