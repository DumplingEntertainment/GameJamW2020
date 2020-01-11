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
                DontDestroyOnLoad(GameManager);
                _instance = new GameManager();
            }
            return _instance;
        }

    }

    private void OnApplicationQuit()
    {
        _instance = null;
    }

    public void Setup()
    {

    }
}
