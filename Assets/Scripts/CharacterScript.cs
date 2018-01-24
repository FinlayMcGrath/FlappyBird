using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float m_jumpForce;
    public GameObject m_retryText, m_gameController;

    Rigidbody m_rigidbody;
    float m_jumpCooldown, m_jumpDelta, m_startTimer;
    int m_score;

	// Use this for initialization
	void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_jumpCooldown = 0.1f;
        m_jumpDelta = 1;
        m_startTimer = 2;
    }
	
	// Update is called once per frame
	void Update ()
    {
        m_startTimer -= Time.deltaTime;

        //if the game has begun
        if (m_startTimer <= 0)
        {
            //if jump button is pressed and can jump (stops spamming jump button)
            if (Input.GetButtonDown("Jump") && m_jumpDelta >= m_jumpCooldown)
            {
                m_rigidbody.AddForce(transform.up * m_jumpForce);
                //temporarily disable gravity
                m_rigidbody.useGravity = false;
                m_jumpDelta -= m_jumpCooldown;
            }
            else
            {
                //fall
                m_rigidbody.useGravity = true;
            }
        }

        if (m_jumpDelta < m_jumpCooldown)
        {
            m_jumpDelta += Time.deltaTime;
        }
   

    }

    void OnTriggerEnter(Collider collision)
    {
        //if a pipe is successfully avoided
        if (collision.gameObject.tag == "Pipe Marker")
        {
            m_score++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if a pipe is hit
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
        //if the player goes out the map
        if (collision.gameObject.tag == "Background")
        {
            //gameover
            m_gameController.GetComponent<GameControllerScript>().Stop();
        }
    }
}
