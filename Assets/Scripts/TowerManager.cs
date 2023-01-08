using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public List<TowerSpot> list = new List<TowerSpot>();

    int nTower;

    private void Start()
    {
        nTower = list.Count;
    }

    public void AddTower()
    {
        nTower--;
        if(nTower == 0)
        {
            GameManager.Instance.Win();
        }
    }
}
