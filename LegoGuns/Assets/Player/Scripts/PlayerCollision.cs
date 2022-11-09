using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lego"))
        {
            collision.gameObject.SetActive(false);
            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            pickUpScript.legosPickedUp++;
            FindObjectOfType<PlayerUpgradeHandler>().UpgradeWeapon(pickUpScript.legosPickedUp);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //GAME OVER
            print("game over");
        }
    }
}
