using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private int legosPickedUp;
    [SerializeField] private LayerMask obstacleLayer;

    private void Start()
    {
        legosPickedUp = 0;
    }

    private void Update()
    {
        CheckForObstacle();
    }

    private void CheckForObstacle()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 10f))
        {
            //start shooting
            print("start shooting");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lego"))
        {
            legosPickedUp++;
            if (legosPickedUp == 4)
            {
                //upgrade gun
                legosPickedUp = 0;
            }
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            //GAME OVER
            print("game over");
        }
    }
}
