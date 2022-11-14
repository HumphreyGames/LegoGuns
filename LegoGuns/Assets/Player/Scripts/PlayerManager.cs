using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private void Update()
    {
        Death();
    }

    #region UPGRADE SYSTEM

    [Header("Upgrade System")]
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

    #endregion

    #region MONEY SYSTEM

    [Header("Money System")]
    public int money;

    public void CollectMoney(int value)
    {
        money += value;
    }

    #endregion

    #region END MULTIPLYER SYSTEM

    [Header("End Multiplyer System")]
    public bool onEndSection;

    #endregion

    #region DEATHSYSTEM

    private void Death()
    {
        if (GetComponent<PlayerPickUp>().bricksPickedUp <= 0)
        {
            FindObjectOfType<PlayerMoveForwards>().enabled = false;
            FindObjectOfType<PlayerPickUp>().enabled = false;
            FindObjectOfType<Camera>().GetComponent<Animator>().SetTrigger("PlayerDeath");
        }
    }

    #endregion
}
