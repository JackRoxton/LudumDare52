using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTower : TowerBase
{
    [SerializeField]
    GameObject turret;


    // Start is called before the first frame update
    void Start()
    {
        range = 2.5f;
        attackSpeed = 2.5f;
        RangeColl = this.GetComponent<CircleCollider2D>();
        RangeColl.radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        if (!currTarget)
            return;
        if(attackTimer <= 0)
        {
            ShootAt(currTarget);
            attackTimer = attackSpeed;
        }
        LookAt(currTarget);
    }

    void LookAt(EnemyBase Enemy)
    {
        Vector2 targ = currTarget.transform.position;
        Vector2 objectPos = turret.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        turret.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void ShootAt(EnemyBase Enemy)
    {
        GameObject tmp = Instantiate(projectile, turret.transform.position,Quaternion.identity);
        tmp.GetComponent<ProjectileBase>().currTarget = this.currTarget;
    }

}
