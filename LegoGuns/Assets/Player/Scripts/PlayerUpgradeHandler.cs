using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeHandler : MonoBehaviour
{
    public GameObject[] weapons;

    public void UpgradeWeapon(int currentWeapon)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == currentWeapon)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
