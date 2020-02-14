using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float speed;
    int ownerID;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    public void setOwnerID(int id)
    {
        ownerID = id;
    }

    public int getOwnerID()
    {
        return ownerID;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject player = other.transform.root.gameObject;
        if(player.CompareTag("Player")){
            if (player.GetComponent<PlayerWeapon>() != null)
            {
                if (!player.GetComponent<PlayerWeapon>().isOwner(ownerID))
                {

                    if (player.GetComponent<PlayerHealth>() != null)
                    {
                        player.GetComponent<PlayerHealth>().dealDamage(damage);
                        Destroy(gameObject);
                    }
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
