﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public GameObject player;
    [Header("Shop Attack Damage Vars")]
    public int attackDamage;
    public Text damageDisplay;
    public Text priceDisplay;

    [Header("Shop Invincibility Vars")]
    public string invinText;
    public Text invinDisplay;
    public Text invinPriceDisplay;

    [Header("Currency Vars")]
    public int coin;
    public int attackDamagePrice;
    public int invinciblePrice;
    public int doubleSpeedPrice;


    public bool invincible;
    public bool dSpeed;

    // Start is called before the first frame update
    void Start()
    {
        attackDamagePrice = 5;
        invinciblePrice = 50;
        invinText = "X";
    }

    // Update is called once per frame
    void Update()
    {
        //Grab Coins from PlayerUICoins Script on Player Object
        coin = player.GetComponent<PlayerUICoins>().coins;

        //Attack Damage Price to Strings
        damageDisplay.text = attackDamage.ToString("0");
        priceDisplay.text = attackDamagePrice.ToString("0");

        //Invincibility Price to Strings
        invinPriceDisplay.text = invinciblePrice.ToString("0");
        invinDisplay.text = invinText.ToString();

    }

    public void AttackIncrease()
    {
        if (coin >= attackDamagePrice)
        {
            //Deducting Price from overall coins in playerUICoins Script
            player.GetComponent<PlayerUICoins>().coins -= attackDamagePrice;
            //Adding money on top of the current price to make pricing much higher next time
            attackDamagePrice += 5;

            //Sending return value to Inventory Script.
            player.GetComponent<Inventory>().strength = true;
            player.GetComponent<Inventory>().OneOrTwo();
            

        }
    }
    public void Invincibility()
    {
        if (!invincible)
        {
            if (coin >= invinciblePrice)
            {
                invincible = true;
                player.GetComponent<PlayerUICoins>().coins -= invinciblePrice;
                invinciblePrice += 15;
                invinText = "✔";
            }
        }
        else if (invincible)
        {
            //Your Already Invincible
            StartCoroutine(AlreadyInvincible());
        }
    }
    #region Coroutines

    IEnumerator AlreadyInvincible()
    {
        invinDisplay.fontSize = 30;
        invinText = "You're Already Invincible";
        yield return new WaitForSeconds(1);
        invinDisplay.fontSize = 60;
        invinText = "✔";
    }
    #endregion
}
