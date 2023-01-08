using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TowerSpot : MonoBehaviour
{
    [SerializeField]
    TowerManager tm;
    public bool strongType;
    float cost;
    public GameObject window, towerWeak, towerStrong;
    public TMP_Text windowText;

    private void Start()
    {
        window.SetActive(false);
        if (strongType)
        {
            cost = 110;
        }
        else
        {
            cost = 35;
        }
        windowText.text = "cost : " + cost;
    }

    private void OnMouseOver()
    {
        window.SetActive(true);
    }

    private void OnMouseExit()
    {
        window.SetActive(false);
    }

    private void OnMouseDown()
    {
        if(GameManager.Instance.GetMoney() < cost)
        {
            return;
        }
        else
        {
            GameManager.Instance.AddMoney(-cost);
            if (strongType)
            {
                Instantiate(towerStrong, this.transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(towerWeak, this.transform.position, Quaternion.identity);
            }
            tm.AddTower();
            //window.SetActive(false);
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }

}
