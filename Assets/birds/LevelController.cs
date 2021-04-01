using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private bluedude[] _bluedudes;
    private static int _nextLevelIndex = 1;

    private void OnEnable()
    {
        _bluedudes = FindObjectsOfType<bluedude>();
    }

    void Update()
    {
        foreach(bluedude bluedude in _bluedudes)
        {
            if (bluedude != null)
            {
                return;
            }

        }
        //Debug.Log("bluedudes are gone");

        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName);
    }
}
