using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    Transform SpawnPoint;
    [SerializeField]
    GameObject FirstEnemy, SecondEnemy, ThirdEnemy;
    [SerializeField]
    Path path;

    float spawnTimer = 4;

    float difficultyValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.enemyManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            spawnTimer = 5 - difficultyValue;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int rand = Random.Range(0, 11);
        GameObject tmp = null;
        if (rand < 5)
        { 
            tmp = Instantiate(FirstEnemy, SpawnPoint.position, Quaternion.identity);
        }
        else if(rand < 8)
        {
            tmp = Instantiate(SecondEnemy, SpawnPoint.position, Quaternion.identity);
        }
        else
        {
            tmp = Instantiate(ThirdEnemy, SpawnPoint.position, Quaternion.identity);
        }

        tmp.GetComponent<EnemyBase>().path = path;
        tmp.GetComponent<EnemyBase>().difficultyValue = this.difficultyValue;
    }

    public void DifficultyChange()
    {
        difficultyValue += 0.1f;
    }
}
