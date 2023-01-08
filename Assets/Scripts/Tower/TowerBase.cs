using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public GameObject projectile;
    protected int damage;
    protected CircleCollider2D RangeColl;
    protected float range;
    protected float attackSpeed;
    protected float attackTimer;
    protected EnemyBase currTarget;

    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (currTarget != null)
            return;
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            currTarget = enemy;
        }
    }
    protected void OnTriggerExit2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy == currTarget)
        {
            currTarget = null;
        }
    }
}
