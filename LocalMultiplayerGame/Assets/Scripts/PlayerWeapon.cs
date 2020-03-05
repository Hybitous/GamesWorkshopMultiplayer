using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    AbstractWeapon currentWeapon;
    [SerializeField] GameObject weaponPrefab;
    PlayerInput playerInput;
    [SerializeField] Transform weaponsHand;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        weaponPickup();
    }

    void weaponPickup()
    {
        var weaponGo = Instantiate(weaponPrefab, weaponsHand);
        currentWeapon = weaponGo.GetComponent<AbstractWeapon>();
    }
    void OnAttack()
    {
        currentWeapon.Attack();
   
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
