using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RPGStatTest : MonoBehaviour
{
    private RPGStatCollection stats;

    void Start()
    {
        stats = new RPGDefaultStats();
        var statTypes = Enum.GetValues(typeof(RPGStatType));
        foreach(var statType in statTypes)
        {
            RPGStat stat = stats.GetStat((RPGStatType)statType);
            if (stat != null)
            {
                Debug.Log(string.Format("Stat {0}'s value is {1}", stat.StatName, stat.StatValue));
            }
        }
    }

}
