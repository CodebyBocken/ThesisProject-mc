using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public int attackPower;
    public int attackSpeed;
    public MeshCollider MeshCollider { get; set; }
    public SO_Weapon startingWeapon;
    // Start is called before the first frame update
    void Start()
    {
        MeshCollider = GetComponent<MeshCollider>();
        LoadWeapon(startingWeapon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadWeapon(SO_Weapon weapon)
    {
        GetComponent<MeshFilter>().mesh = weapon.weaponMesh;
        MeshCollider.sharedMesh = weapon.weaponMesh;
        attackPower = weapon.attackPower;
        attackSpeed = weapon.attackSpeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(attackPower, attackSpeed);
        }
    }
}
