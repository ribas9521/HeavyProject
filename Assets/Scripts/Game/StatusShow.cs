using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusShow : MonoBehaviour
{

    StatusController sc;
    PlayerStatus ps;
    MovementController mc;
    Text pAttackText, mAttackText, criticalCText, criticalMText, accuracyText,
        strText, agiText, inteText, dexText, aSpeedText, mSpeedText, pointsText;
    


    void Start()
    {
        sc = GameObject.FindGameObjectWithTag("Player").GetComponent<StatusController>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        pAttackText = transform.Find("StatsBg").Find("PAttackText").GetComponent<Text>();
        mAttackText = transform.Find("StatsBg").Find("MAttackText").GetComponent<Text>();
        criticalCText = transform.Find("StatsBg").Find("CriticalChanceText").GetComponent<Text>();
        criticalMText = transform.Find("StatsBg").Find("CriticalMultiplierText").GetComponent<Text>();
        accuracyText = transform.Find("StatsBg").Find("AccuracyText").GetComponent<Text>();
        strText = transform.Find("StatsBg").Find("StrText").GetComponent<Text>();
        agiText = transform.Find("StatsBg").Find("AgiText").GetComponent<Text>();
        inteText = transform.Find("StatsBg").Find("IntText").GetComponent<Text>();
        dexText = transform.Find("StatsBg").Find("DexText").GetComponent<Text>();
        aSpeedText = transform.Find("StatsBg").Find("ASpeedText").GetComponent<Text>();
        mSpeedText = transform.Find("StatsBg").Find("MSpeedText").GetComponent<Text>();
        pointsText = transform.Find("StatsBg").Find("PointsText").GetComponent<Text>();
    }

  
    void Update()
    {
        getStats();
    }

    public void getStats()
    {
        pAttackText.text = "P.Attack: " + sc.pAttack.ToString();
        mAttackText.text = "M.Attack: " + sc.mAttack.ToString();
        criticalCText.text = "Critical C: " + sc.criticalChance.ToString();
        criticalMText.text = "Critical M: " + sc.criticalMultiplier.ToString();
        accuracyText.text = "Accuracy: " + sc.accuracy.ToString();
        strText.text = "Str: " + sc.str.ToString();
        agiText.text = "Agi: " + sc.agi.ToString();
        inteText.text = "Inte: " + sc.inte.ToString();
        dexText.text = "Dex: " + sc.dex.ToString();
        aSpeedText.text = "Atk.Speed: " + mc.attackSpeed;
        mSpeedText.text = "Atk.Speed: " + mc.moveSpeed;
        pointsText.text = "Unspent Points: " + ps.points;
    }

    public void changeStr(int amount)
    {
        if (amount == -1 && sc.str <= 0)
        {
            sc.str = 0;
            updatePoints(0);
        }
        else
        {
            if (amount == 1)
            {
                if (ps.points > 0)
                {
                    sc.str += amount;
                    updatePoints(amount);
                }
            }
            else
            {
                if (ps.str > 0)
                {
                    sc.str += amount;
                    updatePoints(amount);
                }
            }
            
        }

        globalUpdateStatus();

    }
    public void changeAgi(int amount)
    {
        if (amount == -1 && sc.agi <= 0)
        {
            sc.agi = 0;
            updatePoints(0);
        }
        else
        {
            if (amount == 1)
            {
                if (ps.points > 0)
                {
                    sc.agi += amount;
                    updatePoints(amount);
                }
            }
            else
            {
                if (ps.agi > 0)
                {
                    sc.agi += amount;
                    updatePoints(amount);
                }
            }

        }

        globalUpdateStatus();
    }

    public void changeInte(int amount)
    {
        if (amount == -1 && sc.inte <= 0)
        {
            sc.inte = 0;
            updatePoints(0);
        }
        else
        {
            if (amount == 1)
            {
                if (ps.points > 0)
                {
                    sc.inte += amount;
                    updatePoints(amount);
                }
            }
            else
            {
                if (ps.inte > 0)
                {
                    sc.inte += amount;
                    updatePoints(amount);
                }
            }

        }

        globalUpdateStatus();
    }

    public void changeDex(int amount)
    {
        if (amount == -1 && sc.dex <= 0)
        {
            sc.dex = 0;
            updatePoints(0);
        }
        else
        {
            if (amount == 1)
            {
                if (ps.points > 0)
                {
                    sc.dex += amount;
                    updatePoints(amount);
                }
            }
            else
            {
                if (ps.dex > 0)
                {
                    sc.dex += amount;
                    updatePoints(amount);
                }
            }

        }

        globalUpdateStatus();
    }

    public void globalUpdateStatus()
    {

        ps.updateStatus();
        ps.UpdateBdStatus();
        getStats();
    }

    public void updatePoints(int amount)
    {
        ps.updatePoints(amount * -1);

    }




}
