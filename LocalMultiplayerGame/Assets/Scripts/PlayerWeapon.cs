using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    AbstractWeapon currentWeapon;
    [SerializeField] AbstractWeapon defaultWeapon;
    PlayerInput playerInput;
    [SerializeField] Transform weaponsHand;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        SwitchWeapon(defaultWeapon);
    }

    void SwitchWeapon(AbstractWeapon weapon)
    {
        var weaponGo = Instantiate(weapon, weaponsHand);
        currentWeapon = weaponGo.GetComponent<AbstractWeapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        WeaponPickUp weaponPickUp = other.gameObject.GetComponent<WeaponPickUp>();
        if (weaponPickUp != null)
        {
            SwitchWeapon(weaponPickUp.getWeapon());
        }
    }


    void OnAttack()
    {
        if (currentWeapon != null)
        {
        currentWeapon.Attack();
        }
   
    }

    public bool isOwner(int id)
    {
        return id == playerInput.playerIndex;
    }

    public int getIndex()
    {
        return playerInput.playerIndex;
    }
}
