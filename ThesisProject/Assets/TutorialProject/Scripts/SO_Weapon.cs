using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_weapon", menuName = "Weapon")]
public class SO_Weapon : ScriptableObject
{
    [Header("Weapon ID")]
    public string weaponName;
    public Mesh weaponMesh;

    [Header("Weapon Stats")]
    public int attackSpeed;
    public int attackPower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
