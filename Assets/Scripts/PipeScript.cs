using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float m_velocity;
    public GameObject m_upperPipe, m_lowerPipe;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(m_velocity * Time.deltaTime, 0, 0);
	}
}
