using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public float m_spawnTimer, m_totalScale;
    public GameObject m_pipes;
    

    // Use this for initialization
    void Start ()
    {
        m_spawnTimer = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (m_spawnTimer >= 3)
        {
            GameObject pipe = Instantiate(m_pipes) as GameObject;
            pipe.transform.Translate(transform.position);
            float scale = Random.Range(1, m_totalScale);
            pipe.transform.GetChild(0).transform.localScale = new Vector3(1, scale, 1);
            pipe.transform.GetChild(1).transform.localScale = new Vector3(1, m_totalScale - scale + 1, 1);
            m_spawnTimer -= 3;
        }
        m_spawnTimer += Time.deltaTime;
	}
}
