﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour {
    // Use this for initialization
    void Start () {

    }

    public void playGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void back()
    {
        SceneManager.LoadScene("StartMenu");
    }

}
