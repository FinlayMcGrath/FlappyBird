using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionScript : MonoBehaviour
{
    float m_lifeSpan = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_lifeSpan -= Time.deltaTime;

        //we only want the instruction to appear for a few seconds
        if (m_lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }
}
