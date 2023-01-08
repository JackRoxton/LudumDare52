using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBase : MonoBehaviour
{
    //public GameObject Loot;
    public Path path;
    protected int nextPathId = 0;
    public Transform currPath = null;
    public Image HPBar;

    protected float hp;
    protected float maxhp;
    protected float speed;
    public float difficultyValue = 1;

    protected void GoToWaypoint()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, currPath.position, speed*Time.deltaTime);
        
        if (this.transform.position == currPath.position)
        {
            GetNextPath();
        }
    }

    protected void GetNextPath()
    {
        currPath = path.NextPath(nextPathId);
        nextPathId++;
    }

    public void TakeDamage(int dmg) 
    {
        this.hp -= dmg;
        HPBar.fillAmount = hp / maxhp;
        if (this.hp <= 0)
            Die();
        AudioManager.Instance.PlayHurt();
    }

    void Die()
    {
        AudioManager.Instance.PlayDie();
        Destroy(this.gameObject);
    }
}
