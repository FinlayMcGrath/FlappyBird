﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public float m_score;
    private Text m_scoreText;
    private CharacterScript m_characterScript;

    // Use this for initialization
    void Start()
    {
        m_scoreText = GetComponent<Text>();
        m_characterScript = FindObjectOfType<CharacterScript>();
    }

    // Update is called once per frame
    void Update()
    {
        m_score = m_characterScript.GetScore();
        m_scoreText.text = "Score: " + m_score.ToString();
    }
}