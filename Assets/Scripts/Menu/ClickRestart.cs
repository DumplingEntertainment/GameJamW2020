﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickRestart : MonoBehaviour
{

    public void restart () {
        SceneManager.LoadScene(sceneBuildIndex:1);
    }
}
