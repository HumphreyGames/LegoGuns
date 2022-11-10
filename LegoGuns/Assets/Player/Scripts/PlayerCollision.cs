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
            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();

            pickUpScript.legosPickedUp++;
            upgradeHandler.UpgradeWeapon(pickUpScript.legosPickedUp);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Choice"))
        {
            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();
            Choice choiceScript = other.gameObject.GetComponent<Choice>();

            pickUpScript.legosPickedUp += choiceScript.value;
            upgradeHandler.UpgradeWeapon(pickUpScript.legosPickedUp);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else if (other.gameObject.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            PlayerManager playerManager = FindObjectOfType<PlayerManager>();
            playerManager.CollectMoney(1);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(other.gameObject);

            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            Health obstacleHealth = other.gameObject.GetComponent<Health>();
            pickUpScript.legosPickedUp -= obstacleHealth.currentHealth;

            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();
            upgradeHandler.UpgradeWeapon(pickUpScript.legosPickedUp);
        }
    }
}
