using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_UI : MonoBehaviour
{
    public GameObject Player;
    public GameObject Weapon;
    public GameObject SceneChanger;


    //All the shop menu options are here
    void Start()
    {
        SceneChanger = GameObject.Find("SceneChanger");
        Player = GameObject.Find("Player");
        Weapon = GameObject.Find("Weapon");
    }

    public void upgradeWeapon()
    {
        Weapon.GetComponent<Weapon_Boomerang_Script>().increaseDamage(2);
        SceneChanger.GetComponent<Scene_Changer>().ToggleShop();
    }

    public void upgradeHealth()
    {
        Player.GetComponent<Player_Main_Script>().increaseMaxHP(30);
        SceneChanger.GetComponent<Scene_Changer>().ToggleShop();
    }

    public void heal()
    {
        Player.GetComponent<Player_Main_Script>().heal(30);
        SceneChanger.GetComponent<Scene_Changer>().ToggleShop();
    }
}
