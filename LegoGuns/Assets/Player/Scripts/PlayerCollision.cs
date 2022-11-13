using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("References")]
    private Animator animator;

    [Header("Destory Effects")]
    [SerializeField] private GameObject obstacle_Beam_DeathFX;
    [SerializeField] private GameObject obstacle_Shootable_DeathFX;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);

            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();

            pickUpScript.bricksPickedUp++;
            upgradeHandler.UpgradeWeapon(pickUpScript.bricksPickedUp);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Choice"))
        {
            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();
            Choice choiceScript = other.gameObject.GetComponent<Choice>();

            pickUpScript.bricksPickedUp += choiceScript.value;
            upgradeHandler.UpgradeWeapon(pickUpScript.bricksPickedUp);
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
            GameObject destroyFX = Instantiate(obstacle_Shootable_DeathFX, other.transform.position, Quaternion.identity);
            destroyFX.transform.parent = GameObject.FindGameObjectWithTag("PlatformParent").transform;

            Destroy(other.gameObject);

            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            Health obstacleHealth = other.gameObject.GetComponent<Health>();
            pickUpScript.bricksPickedUp -= obstacleHealth.currentHealth;

            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();
            upgradeHandler.UpgradeWeapon(pickUpScript.bricksPickedUp);
        }
        else if (other.gameObject.CompareTag("ObstacleBeam"))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;

            GameObject destroyFX = Instantiate(obstacle_Beam_DeathFX, other.transform.position, Quaternion.identity);
            destroyFX.transform.parent = GameObject.FindGameObjectWithTag("PlatformParent").transform;

            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            pickUpScript.bricksPickedUp -= 1;

            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();
            upgradeHandler.UpgradeWeapon(pickUpScript.bricksPickedUp);
        }
        else if (other.gameObject.CompareTag("Multiplyer"))
        {
            print("end of level");
        }
    }
}
