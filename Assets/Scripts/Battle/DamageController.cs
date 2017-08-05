using UnityEngine;
using System.Collections;

public class DamageController : MonoBehaviour {

    public bool critical =false;
    public bool block = false;
    public bool miss =false;


    public void TakeDamage(GameObject enemie, float pAttack, float mAttack, float pDefense, float mDefense, float hPoints,
        float mPoints, float criticalChance, float criticalMultiplier, float evasionChance, float accuracy,
        float blockChance)
    {

        float pDamage;
        float mDamage;
        StatusController enemieStatus = enemie.GetComponent<StatusController>();

        pDamage = ((pAttack * CriticalCalculator(criticalChance, criticalMultiplier)) - enemieStatus.pDefense)
            * MissCalculator(enemieStatus.evasionChance, accuracy) * BlockCalculator(enemieStatus.blockChance);

        mDamage = (mAttack - enemieStatus.mDefense); 

        if(pDamage < 0)
        {
            pDamage = 0;
        }
        if (mDamage < 0)
        {
            mDamage = 0;
        }

        enemieStatus.hPoints -= pDamage + mDamage;

        BattleTextController bText = enemie.GetComponent<BattleTextController>();
        if (miss)
        {
            bText.miss();
            miss = false;
            critical = false;
            block = false;
        }
        else if (block)
        {
            bText.block();
            critical = false;
            block = false;
        }
        else if (critical)
        {
            bText.critical(pDamage + mDamage);
            critical = false;
        }
        else
            bText.damage(pDamage + mDamage);
        

        
    }

    float CriticalCalculator(float criticalChance, float criticalMultiplier)
    {        
        float r = Random.Range(0, 100);
        
        if (r < criticalChance * 10)
        {
            critical = true;
            return criticalMultiplier;
        }
        else
            return 1;
    }

    float MissCalculator(float evasionChance, float accuracy)
    {
        float r = Random.Range(0, 100);

        if (r < ((evasionChance - accuracy)-1) * 10)
        {
            miss = true;
            return 0;
        }
        else
            return 1;
    }

    float BlockCalculator(float blockChance)
    {
        float r = Random.Range(0, 100);

        if (r < blockChance * 10)
        {
            block = true;
            return 0;
        }
        else
            return 1;
    }


}
