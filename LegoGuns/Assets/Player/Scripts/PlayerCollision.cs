using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lego"))
        {
            print("collided");
            Destroy(collision.gameObject);
            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            PlayerUpgradeHandler upgradeHandler = FindObjectOfType<PlayerUpgradeHandler>();

            pickUpScript.legosPickedUp++;
            upgradeHandler.UpgradeWeapon(pickUpScript.legosPickedUp);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //GAME OVER
            print("game over");
        }
    }
}
