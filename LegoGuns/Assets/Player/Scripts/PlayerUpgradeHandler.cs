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

        weapons[currentWeapon].SetActive(true);
    }

    private void Update()
    {
        weapons[currentWeapon].SetActive(true);
    }
}
