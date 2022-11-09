using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [Header("References")]
    private PlayerUpgradeHandler upgradeHandler;

    [Header("Data")]
    public int legosPickedUp;
    [SerializeField] private LayerMask obstacleLayer;

    [Header("Shooting Data")]
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private GameObject bulletObj;

    private void Start()
    {
        upgradeHandler = GetComponent<PlayerUpgradeHandler>();

        legosPickedUp = 0;
    }

    private void Update()
    {
        CheckForObstacle();
    }

    private void CheckForObstacle()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 10f))
        {
            //Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletObj, transform.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(10 * Time.deltaTime * transform.forward);
    }
}
