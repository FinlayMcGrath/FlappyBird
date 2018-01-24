using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float m_jumpForce;
    public GameObject m_retryText, m_gameController;

    Rigidbody m_rigidbody;
    float m_jumpCooldown, m_jumpDelta;
    int m_score;

	// Use this for initialization
	void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_jumpForce = 500;
        m_jumpCooldown = 0.1f;
        m_jumpDelta = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Jump") && m_jumpDelta >= m_jumpCooldown)
        {
            m_rigidbody.AddForce(transform.up * m_jumpForce);
            m_rigidbody.useGravity = false;
            m_jumpDelta -= m_jumpCooldown;
        }
        else
        {
            m_rigidbody.useGravity = true;
        }

        if (m_jumpDelta < m_jumpCooldown)
        {
            m_jumpDelta += Time.deltaTime;
        }
        
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Pipe Marker")
        {
            m_score++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Pipe")
        {
            //gameover
            m_gameController.GetComponent<GameControllerScript>().Stop();
        }
    }

    public int GetScore()
    {
        return m_score;
    }
    
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Background")
        {
            m_gameController.GetComponent<GameControllerScript>().Stop();
        }
    }
}
