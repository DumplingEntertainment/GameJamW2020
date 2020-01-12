using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    private GameManager()
    {
    }

    public static GameManager Instance
    {
        get {
            if (_instance == null)
            {
                DontDestroyOnLoad(_instance);
                _instance = new GameManager();
            }
            return _instance;
        }

    }


    void Dead() {
        Debug.Log("Event received");
    }

    private void OnApplicationQuit()
    {
        _instance = null;
    }

    public void Setup()
    {

    }
}
