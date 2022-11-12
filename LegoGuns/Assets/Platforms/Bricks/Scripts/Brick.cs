using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Transform[] positions;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPickUp pickUp = FindObjectOfType<PlayerPickUp>();
            GetComponent<BoxCollider>().enabled = false;

            if (pickUp.bricksPickedUp == 2)
            {
                Vector3 firstPositionToMoveTo = new(transform.position.x, transform.position.y + 1f, transform.position.z);

                StartCoroutine(LerpFirstPosition(firstPositionToMoveTo, 0.25f, positions[0].position, positions[0]));
                StartCoroutine(LerpRotation(positions[0].rotation, 0.25f));
            }
            else if (pickUp.bricksPickedUp == 3)
            {
                GetComponent<MeshRenderer>().material.color = Color.red;

                Vector3 firstPositionToMoveTo = new(transform.position.x, transform.position.y + 1f, transform.position.z);

                StartCoroutine(LerpFirstPosition(firstPositionToMoveTo, 0.25f, positions[1].position, positions[1]));
                StartCoroutine(LerpRotation(positions[1].rotation, 0.25f));
            }
            else if (pickUp.bricksPickedUp == 4)
            {
                print("pistol_03");
            }
            else if (pickUp.bricksPickedUp == 5)
            {
                print("pistol_04");
            }
        }
    }

    IEnumerator LerpFirstPosition(Vector3 targetPosition, float duration, Vector3 secondTargetPosition, Transform parent)
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

        StartCoroutine(LerpSecondPosition(secondTargetPosition, 0.25f, parent));
    }

    IEnumerator LerpSecondPosition(Vector3 targetPosition, float duration, Transform parent)
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
        transform.parent = parent;
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
