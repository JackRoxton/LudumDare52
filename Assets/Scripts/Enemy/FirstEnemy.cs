using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstEnemy : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        GetNextPath();
        speed = 1f;
        hp = 40f * difficultyValue;
        maxhp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        GoToWaypoint();
    }
}
