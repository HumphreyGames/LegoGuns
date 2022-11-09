using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lego"))
        {
            Destroy(collision.gameObject);
            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            PlayerUpgradeHandler upgradeHandler = FindObjectOfType<PlayerUpgradeHandler>();

            pickUpScript.legosPickedUp++;
            upgradeHandler.UpgradeWeapon(pickUpScript.legosPickedUp);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //GAME OVER
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Choice"))
        {
            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            PlayerUpgradeHandler upgradeHandler = FindObjectOfType<PlayerUpgradeHandler>();
            Choice choiceScript = other.gameObject.GetComponent<Choice>();

            pickUpScript.legosPickedUp += choiceScript.value;
            upgradeHandler.UpgradeWeapon(choiceScript.value);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
