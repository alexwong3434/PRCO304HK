using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBirds : MonoBehaviour
{
    public GameObject bird;

    void Update()
    {
     if (Input.GetMouseButtonDown(0))
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(bird, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
        }
    }
}
