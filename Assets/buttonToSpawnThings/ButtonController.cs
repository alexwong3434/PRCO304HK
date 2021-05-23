using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private string _buttonName;
    [SerializeField]
    private GameObject _gameObjectToSpawn;

    public void SpawnBird()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        Instantiate(_gameObjectToSpawn, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
