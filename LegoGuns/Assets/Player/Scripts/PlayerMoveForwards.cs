using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveForwards : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        transform.position += transform.forward * (-speed * Time.deltaTime);
    }
}
