using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPart : MonoBehaviour
{
    [Header("SHOTGUN")]
    [SerializeField] private Transform shotgunPoint;
    [SerializeField] private GameObject shotgunPart;
    [SerializeField] private Color newColour;

    [Header("Data")]
    bool canUpgrade;

    private void Start()
    {
        canUpgrade = true;

        shotgunPoint = GameObject.Find("ShotgunPoint_" + transform.name).transform;
    }

    private void Update()
    {
        PlayerPickUp pickupScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickUp>();
        if (pickupScript.aliensPickedUp == 5 && canUpgrade)
        {
            canUpgrade = false;

            StartCoroutine(LerpPosition(shotgunPoint.position, 0.4f));
            StartCoroutine(LerpRotation(shotgunPoint.rotation, 0.4f));
            StartCoroutine(InstantiateNewUpgrade());
        }
    }

    IEnumerator InstantiateNewUpgrade()
    {
        yield return new WaitForSeconds(0.4f);

        GameObject alien = Instantiate(shotgunPart, shotgunPoint.position, shotgunPoint.rotation);
        alien.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        alien.GetComponentInChildren<SkinnedMeshRenderer>().material.color = newColour;

        Destroy(gameObject);
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    IEnumerator LerpRotation(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endValue;
    }
}
