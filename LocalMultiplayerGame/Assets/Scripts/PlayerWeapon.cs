using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject boomerang;
    PlayerInput playerInput;
    public int weaponMode = 0;
    // Start is called before the first frame update
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }


    void OnAttack()
    {
        if (weaponMode == 0)
        {
            GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
            projectile.GetComponent<Projectile>().setOwnerID(playerInput.playerIndex);
        }
        if (weaponMode == 1)
        {
            GameObject projectile = Instantiate(boomerang, transform.position, transform.rotation);
            projectile.GetComponent<Boomerang>().setOwnerID(playerInput.playerIndex);
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
