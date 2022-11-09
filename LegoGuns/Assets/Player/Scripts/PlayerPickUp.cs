using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [Header("References")]
    private PlayerUpgradeHandler upgradeHandler;

    [Header("Data")]
    public int legosPickedUp;

    [Header("Shooting Data")]
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private GameObject bulletObj;
    [SerializeField] private float fireRate;
    [SerializeField] private float shootForce;
    private float fireCountdown;

    [Header("Obstacle Detection")]
    [SerializeField] private LayerMask obstacleLayer;

    private void Start()
    {
        upgradeHandler = GetComponent<PlayerUpgradeHandler>();

        legosPickedUp = 0;
    }

    private void Update()
    {
        CheckForObstacle();
    }

    #region Obstacle Detection + Shooting

    private void CheckForObstacle()
    {
        RaycastHit hit;
        Ray ray = new Ray(muzzlePoint.position, -muzzlePoint.forward);
        if (Physics.Raycast(ray, out hit, 5f) && fireCountdown <= 0)
        {
            if (hit.transform.gameObject.CompareTag("Obstacle"))
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletObj, muzzlePoint.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody>().AddForce(-muzzlePoint.forward * shootForce);
    }

    #endregion
}
