using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{

    [SerializeField] AbstractWeapon weapon;

    public AbstractWeapon getWeapon()
    {
        return weapon;
    }
}
