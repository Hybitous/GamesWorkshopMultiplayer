using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 3;
    int hp;
    PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        playerInput = GetComponent<PlayerInput>();
    }

    public void dealDamage(int amount)
    {
        hp -= amount;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Death();
        }
        
    }

    void Death()
    {
        hp = maxHP;
        transform.position = Vector3.up * 7;
        Debug.Log("Player " + playerInput.playerIndex + " died.");
    }
}
