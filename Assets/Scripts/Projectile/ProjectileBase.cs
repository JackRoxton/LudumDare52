using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    protected int damage;
    protected int speed;

    public EnemyBase currTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void LookAtEnemy()
    {
        if (!currTarget)
            Destroy(this.gameObject);

        Vector2 targ = currTarget.transform.position;
        Vector2 objectPos = this.transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        if (this.gameObject.GetComponent<SecondProjectile>())
        {
            angle -= 90;
        }
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    protected void GoToEnemy()
    {
        if (!currTarget)
            Destroy(this.gameObject);

        this.transform.position = Vector2.MoveTowards(this.transform.position, currTarget.transform.position, speed * Time.deltaTime);

        if (this.transform.position == currTarget.transform.position)
        {
            currTarget.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
