using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        moneyCountText = GameObject.FindGameObjectWithTag("MoneyText").GetComponent<TextMeshProUGUI>();
    }

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
    [SerializeField] private TextMeshProUGUI moneyCountText;
    public int currentMoney;

    public void CollectMoney(int value)
    {
        currentMoney += value;
        moneyCountText.text = "$" + currentMoney.ToString();
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
