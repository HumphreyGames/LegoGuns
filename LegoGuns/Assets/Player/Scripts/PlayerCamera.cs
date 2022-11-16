using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float maxPositionX;

    void Update()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -maxPositionX, maxPositionX);

        transform.position = clampedPosition;
    }
}
