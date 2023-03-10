using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Loot loot = collision.gameObject.GetComponent<Loot>();
        if(loot && !loot.isDragged)
        {
            Destroy(loot.gameObject);
            GameManager.Instance.AddMoney(10);
            AudioManager.Instance.PlayMoney();
        }
    }
}
