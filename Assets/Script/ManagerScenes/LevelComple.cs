﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComple : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
