using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameObject hitFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<Health>().TakeDamage(damage);

            GameObject destroyFX = Instantiate(hitFX, other.transform.position, Quaternion.identity);
            destroyFX.transform.parent = GameObject.FindGameObjectWithTag("PlatformParent").transform;

            Destroy(gameObject);
        }
    }
}
