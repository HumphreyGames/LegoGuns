using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NewGunTypeToSwitchTo
{
    SMG,
    SHOTGUN,
}

public class GunPart : MonoBehaviour
{
    [Header("ENUM")]
    [SerializeField] private NewGunTypeToSwitchTo newGunType;

    [Header("SMG")]
    [Space(20)]
    [SerializeField] private Transform smgPoint;
    [SerializeField] private GameObject smgPart;

    [Header("SHOTGUN")]
    [Space(20)]
    [SerializeField] private Transform shotgunPoint;
    [SerializeField] private GameObject shotgunPart;

    [Header("Data")]
    [SerializeField] private Color newColour;
    [SerializeField] private bool hasSMGPoints;
    [SerializeField] private bool hasShotgunPoints;
    bool canUpgrade;

    private void Start()
    {
        canUpgrade = true;

        if (hasSMGPoints)
            smgPoint = GameObject.Find("SMGPoint_" + transform.name).transform;
        if (hasShotgunPoints)
            shotgunPoint = GameObject.Find("ShotgunPoint_" + transform.name).transform;
    }

    private void Update()
    {
        PlayerPickUp pickupScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickUp>();
        if (pickupScript.aliensPickedUp == 5 && canUpgrade)
        {
            canUpgrade = false;

            if (hasSMGPoints)
            {
                StartCoroutine(LerpPosition(smgPoint.position, 0.4f));
                StartCoroutine(LerpRotation(smgPoint.rotation, 0.4f));
                StartCoroutine(InstantiateNewUpgrade());
            }
        }
        else if (pickupScript.aliensPickedUp == 9 && canUpgrade)
        {
            if (hasShotgunPoints)
            {
                StartCoroutine(LerpPosition(shotgunPoint.position, 0.4f));
                StartCoroutine(LerpRotation(shotgunPoint.rotation, 0.4f));
                StartCoroutine(InstantiateNewUpgrade());
            }
        }
    }

    IEnumerator InstantiateNewUpgrade()
    {
        yield return new WaitForSeconds(0.4f);

        switch (newGunType)
        {
            case NewGunTypeToSwitchTo.SMG:
                GameObject alienSMG = Instantiate(smgPart, smgPoint.position, smgPoint.rotation);
                alienSMG.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                alienSMG.GetComponentInChildren<SkinnedMeshRenderer>().material.color = newColour;
                break;
            case NewGunTypeToSwitchTo.SHOTGUN:
                GameObject alienShotgun = Instantiate(shotgunPart, shotgunPoint.position, shotgunPoint.rotation);
                alienShotgun.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
                alienShotgun.GetComponentInChildren<SkinnedMeshRenderer>().material.color = newColour;
                break;
        }

        canUpgrade = true;
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
