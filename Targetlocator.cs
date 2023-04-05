using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetlocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileparticles;
    [SerializeField] float range = 15f;
                      Transform target;

   
    void Start()
    {
        FindclosestTarget();
        Aimweapon();
    }
    void FindclosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance<maxDistance)

            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

  
    void Update()
    {
        Aimweapon();
    }

    void Aimweapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.LookAt(target);
        if(targetDistance<range)
        {
            Attack(true);

        }
        else
        {
            Attack(false);
        }
    }
    void Attack(bool isActive)
    {
        var emissiomodule = projectileparticles.emission;
        emissiomodule.enabled = isActive;
    }
}
