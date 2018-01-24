using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleterScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Pipe" || collision.gameObject.tag == "Pipe Marker")
        {
            Destroy(collision.gameObject);
        }
    }
}
