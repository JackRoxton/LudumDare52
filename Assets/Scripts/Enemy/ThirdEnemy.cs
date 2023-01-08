using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEnemy : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        GetNextPath();
        speed = 1.3f;
        hp = 25f * difficultyValue;
        maxhp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        GoToWaypoint();
    }
}
