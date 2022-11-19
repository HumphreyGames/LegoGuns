using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [Header("Components")]
    private Animator animator;

    [Header("Data")]
    [SerializeField] private float amountToLerpUp;

    [Space(20)]
    [SerializeField] private GameObject[] upgrades;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartUpgrade()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        PlayerPickUp pickUpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickUp>();
        animator.SetTrigger("Upgrade_" + pickUpScript.aliensPickedUp);
    }

    private void InstantiateUpgrade()
    {
        PlayerPickUp pickUpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickUp>();
        GameObject alien = Instantiate(upgrades[pickUpScript.aliensPickedUp - 2], transform.position, transform.rotation);
        alien.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(gameObject);
    }
}
