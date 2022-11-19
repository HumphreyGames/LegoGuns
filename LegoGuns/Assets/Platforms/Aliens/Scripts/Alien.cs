using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorExtensions
{
    public static Color ToColor(this string color)
    {
        return (Color)typeof(Color).GetProperty(color.ToLowerInvariant()).GetValue(null, null);
    }
}

public class Alien : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private float amountToLerpUp;

    [Space(20)]
    [SerializeField] private GameObject[] upgrades;
    [SerializeField] private GameObject[] upgradePoints;
    [SerializeField] private string[] upgradesColours;

    public void StartUpgrade()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        PlayerPickUp pickUpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickUp>();

        StartCoroutine(LerpPosition(upgradePoints[pickUpScript.aliensPickedUp - 2].transform.position, 0.4f));
        StartCoroutine(LerpRotation(upgradePoints[pickUpScript.aliensPickedUp - 2].transform.rotation, 0.4f));
        StartCoroutine(InstantiateNewUpgrade());
    }

    IEnumerator InstantiateNewUpgrade()
    {
        yield return new WaitForSeconds(0.4f);

        PlayerPickUp pickUpScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPickUp>();

        GameObject alien = Instantiate(upgrades[pickUpScript.aliensPickedUp - 2], upgradePoints[pickUpScript.aliensPickedUp - 2].transform.position, upgradePoints[pickUpScript.aliensPickedUp - 2].transform.rotation);

        alien.transform.parent = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.black;
        alien.GetComponentInChildren<SkinnedMeshRenderer>().material.color = upgradesColours[pickUpScript.aliensPickedUp - 2].ToColor();

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
