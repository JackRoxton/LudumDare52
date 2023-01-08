using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject loot;
    float spawnTimer = 5;
    Bounds spr;

    private void Start()
    {
        spr = this.GetComponent<SpriteRenderer>().bounds;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            SpawnCrop();
            spawnTimer = 5;
        }
    }

    Vector2 RandomPos()
    {
        float x = Random.Range(-spr.size.x / 2, spr.size.x / 2);
        float y = Random.Range(-spr.size.y / 2, spr.size.y / 2);
        return new Vector2(x,y);
    }

    void SpawnCrop()
    {
        Vector2 tmp = new Vector2(this.transform.position.x, this.transform.position.y);
        Instantiate(loot, tmp + RandomPos(), Quaternion.identity);
    }
}
