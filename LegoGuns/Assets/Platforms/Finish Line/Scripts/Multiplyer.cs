using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMoveForwards>().enabled = false;
            FindObjectOfType<PlayerPickUp>().enabled = false;
        }
    }
}
