using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemy : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        GetNextPath();
        speed = 0.7f;
        hp = 60f * difficultyValue;
        maxhp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        GoToWaypoint();
    }
}
