using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    PlayerInput playerInput;
    // Start is called before the first frame update
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }


    void OnAttack()
    {
        GameObject projectile = Instantiate(bullet, transform.position, transform.rotation);
        projectile.GetComponent<Projectile>().setOwnerID(playerInput.playerIndex);
    }

    public bool isOwner(int id)
    {
        return id == playerInput.playerIndex;
    }
}
