using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform muzzlePoint;

    [Header("Components")]
    private Animator animator;

    [Header("Destory Effects")]
    [SerializeField] private GameObject obstacle_Beam_DeathFX;
    [SerializeField] private GameObject obstacle_Shootable_DeathFX;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        DetectAlien();
    }

    private void DetectAlien()
    {
        RaycastHit hit;
        Ray ray = new(muzzlePoint.position, -muzzlePoint.forward);
        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            if (hit.transform.gameObject.CompareTag("Alien"))
            {
                GetComponentInParent<PlayerPickUp>().aliensPickedUp++;
                hit.transform.gameObject.GetComponent<Alien>().StartUpgrade();
                animator.SetTrigger("Upgrade_" + GetComponentInParent<PlayerPickUp>().aliensPickedUp.ToString());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Choice"))
        {
            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();
            Choice choiceScript = other.gameObject.GetComponent<Choice>();

            pickUpScript.aliensPickedUp += choiceScript.value;
            upgradeHandler.UpgradeWeapon(pickUpScript.aliensPickedUp);
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
            pickUpScript.aliensPickedUp -= obstacleHealth.currentHealth;

            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();
            upgradeHandler.UpgradeWeapon(pickUpScript.aliensPickedUp);
        }
        else if (other.gameObject.CompareTag("ObstacleBeam"))
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;

            GameObject destroyFX = Instantiate(obstacle_Beam_DeathFX, other.transform.position, Quaternion.identity);
            destroyFX.transform.parent = GameObject.FindGameObjectWithTag("PlatformParent").transform;

            PlayerPickUp pickUpScript = FindObjectOfType<PlayerPickUp>();
            pickUpScript.aliensPickedUp -= 1;

            PlayerManager upgradeHandler = FindObjectOfType<PlayerManager>();
            upgradeHandler.UpgradeWeapon(pickUpScript.aliensPickedUp);
        }
        else if (other.gameObject.CompareTag("Multiplyer"))
        {
            print("end of level");
        }
    }
}
