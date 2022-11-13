using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [Header("References")]
    private PlayerManager upgradeHandler;

    [Header("Data")]
    public int bricksPickedUp;

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
        upgradeHandler = GetComponent<PlayerManager>();

        bricksPickedUp = 1;
    }

    private void Update()
    {
        CheckForObstacle();

        if (bricksPickedUp <= 0)
        {
            //GAME OVER
        }
    }

    #region Obstacle Detection + Shooting

    private void CheckForObstacle()
    {
        RaycastHit hit;
        Ray ray = new(muzzlePoint.position, -muzzlePoint.forward);
        Debug.DrawRay(muzzlePoint.position, -muzzlePoint.forward, Color.red);
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
