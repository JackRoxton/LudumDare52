using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase enemy = collision.gameObject.GetComponent<EnemyBase>();
        if (enemy)
        {
            GameManager.Instance.GameOver();
        }
    }
}
