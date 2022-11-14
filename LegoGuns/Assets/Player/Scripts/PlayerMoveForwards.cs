using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForwards : MonoBehaviour
{
    [HideInInspector] public bool startMoving;
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        if (startMoving)
            transform.position += transform.forward * (-speed * Time.deltaTime);
    }
}
