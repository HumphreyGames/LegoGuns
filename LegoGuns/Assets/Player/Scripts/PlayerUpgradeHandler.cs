using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeHandler : MonoBehaviour
{
    public GameObject[] weapons;
    public int currentWeapon;

    private void Start()
    {
        currentWeapon = 0;

        weapons[currentWeapon].GetComponent<MeshRenderer>().enabled = true;
        weapons[currentWeapon].GetComponent<BoxCollider>().enabled = true;
    }

    private void Update()
    {
        currentWeapon = GetComponent<PlayerPickUp>().legosPickedUp;
        weapons[currentWeapon].GetComponent<MeshRenderer>().enabled = true;
        weapons[currentWeapon].GetComponent<BoxCollider>().enabled = true;
    }
}
