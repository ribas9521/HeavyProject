using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsModel : MonoBehaviour {
    int[] item = new int[1];
    //[0] = cost    

    public int[] fireTower()
    {
        int cost = 35;
        return new int[] { cost };
    }
    public int[] waterTower()
    {
        int cost = 35;
        return new int[] { cost };
    }
    public int[] earthTower()
    {
        int cost = 35;
        return new int[] { cost };
    }
    public int[] windTower()
    {
        int cost = 30;
        return new int[] { cost };
    }

    public int[] defaultTower()
    {
        int cost = 15;
        return new int[] { cost };
    }
}
