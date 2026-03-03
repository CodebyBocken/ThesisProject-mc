using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour, F_IInteractable
{
    public SO_Weapon weapon;
    
    public void Interact()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerWeapon>().LoadWeapon(weapon);
        Destroy(gameObject);
    }

}
