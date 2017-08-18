using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusController : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float pAttack;
    [Range(0.0f, 10.0f)]
    public float mAttack;
    [Range(0.0f, 10.0f)]
    public float pDefense;
    [Range(0.0f, 10.0f)]
    public float mDefense;
    [Range(0.0f, 100.0f)]
    public float hPoints;
    public float maxHPoints;
    [Range(0.0f, 10.0f)]
    public float mPoints;
    [Range(0.0f, 10.0f)]
    public float criticalChance;
    [Range(0.0f, 10.0f)]
    public float criticalMultiplier;
    [Range(0.0f, 10.0f)]
    public float evasionChance;
    [Range(0.0f, 10.0f)]
    public float accuracy;
    [Range(0.0f, 10.0f)]
    public float blockChance;
    [Range(0.0f, 100.0f)]
    public float reward;

    public float str;
    public float agi;
    public float inte;
    public float dex;
    public int points;

    private void Awake()
    {
        maxHPoints = hPoints;
      
    }
   

}
