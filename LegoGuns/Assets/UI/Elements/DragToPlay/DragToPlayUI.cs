using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToPlayUI : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindObjectOfType<PlayerMoveForwards>().startMoving = true;
            gameObject.SetActive(false);
        }
    }
}