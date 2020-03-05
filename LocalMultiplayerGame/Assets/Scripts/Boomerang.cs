using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Projectile
{

    [SerializeField] int damage;
    [SerializeField] float speed;
    [SerializeField] float distance;
    [SerializeField] float hoverTime;
    [SerializeField] float successiveDamageTime;
    [SerializeField] float extraReturnTime = .3f;
    [SerializeField] float initialResistanceTime = .2f;
    private float startTime;
    private bool returning = false;
    private bool hovering = false;
    private List<int> resistantPlayers = new List<int>();


    private void Awake()
    {
        startTime = Time.time;
        Destroy(gameObject, distance/speed * 2 + hoverTime + extraReturnTime);
    }

    private void Update()
    {
        if (Time.time - startTime < distance/speed)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (! hovering)
        {
            hovering = true;
            Invoke("Return", hoverTime);
        }
        if (returning)
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.transform.root.gameObject;
        if (player.CompareTag("Player"))
        {
            if (player.GetComponent<PlayerHealth>() != null && ! resistantPlayers.Contains(player.GetComponent<PlayerWeapon>().getIndex()))
            {
                if (! (player.GetComponent<PlayerWeapon>().isOwner(getOwnerID()) && Time.time - startTime < initialResistanceTime))
                {
                    player.GetComponent<PlayerHealth>().dealDamage(damage);
                    resistantPlayers.Add(player.GetComponent<PlayerWeapon>().getIndex());
                    Invoke("RemoveFromResistantPlayers", successiveDamageTime);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Return()
    {
        returning = true;
    }

    void RemoveFromResistantPlayers()
    {
        resistantPlayers.RemoveAt(0);
    }



}
