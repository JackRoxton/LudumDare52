using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstProjectile : ProjectileBase
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        damage = 25;
    }

    // Update is called once per frame
    void Update()
    {
        if (!currTarget)
            Destroy(this.gameObject);
        LookAtEnemy();
        GoToEnemy();
    }
}
