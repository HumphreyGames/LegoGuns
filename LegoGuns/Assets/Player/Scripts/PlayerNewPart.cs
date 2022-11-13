using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNewPart : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform targetPosition;
    public string targetPositionName;

    private void Start()
    {
        transform.localScale = new(1f, 1f, 1f);
        targetPosition = GameObject.Find(targetPositionName).transform;
        targetPosition.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(LerpFirstPosition(targetPosition, 0.25f));
        StartCoroutine(LerpRotation(targetPosition.rotation, 0.25f));
    }

    IEnumerator LerpFirstPosition(Transform targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition.position;
    }

    IEnumerator LerpRotation(Quaternion targetRotation, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;
        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, targetRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetRotation;
    }
}
