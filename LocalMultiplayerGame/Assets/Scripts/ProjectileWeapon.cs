using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon: AbstractWeapon
{

    [SerializeField] Projectile projectile;

    public int playerId { get; set; }

    public override void Attack()
    {
        var projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
        projectileInstance.setOwnerID(playerId);
    }
}
