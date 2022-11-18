using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] private Transform[] positions;
    [SerializeField] private Transform newPartSpawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPickUp pickUp = FindObjectOfType<PlayerPickUp>();
            GetComponent<BoxCollider>().enabled = false;

            if (pickUp.aliensPickedUp == 2)
            {
                GameObject newPart = Instantiate(positions[0].gameObject, newPartSpawnPoint.position, Quaternion.identity);
                Transform newPartParent = GameObject.Find(newPart.GetComponent<PlayerNewPart>().targetPositionName).transform;
                newPart.transform.parent = newPartParent;
            }
            else if (pickUp.aliensPickedUp == 3)
            {
                GameObject newPart = Instantiate(positions[1].gameObject, newPartSpawnPoint.position, Quaternion.identity);
                Transform newPartParent = GameObject.Find(newPart.GetComponent<PlayerNewPart>().targetPositionName).transform;
                newPart.transform.parent = newPartParent;
            }
            else if (pickUp.aliensPickedUp == 4)
            {
                GameObject newPart = Instantiate(positions[2].gameObject, newPartSpawnPoint.position, Quaternion.identity);
                Transform newPartParent = GameObject.Find(newPart.GetComponent<PlayerNewPart>().targetPositionName).transform;
                newPart.transform.parent = newPartParent;
            }
            else if (pickUp.aliensPickedUp == 5)
            {
                GameObject newPart = Instantiate(positions[3].gameObject, newPartSpawnPoint.position, Quaternion.identity);
                Transform newPartParent = GameObject.Find(newPart.GetComponent<PlayerNewPart>().targetPositionName).transform;
                newPart.transform.parent = newPartParent;
            }
        }
    }
}
