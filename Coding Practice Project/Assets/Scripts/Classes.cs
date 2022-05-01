using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Classes
{
    public int itemID;
    public string itemName;

    public Classes(int id, string name)
    {
        this.itemID = id;
        this.itemName = name;
    }
}
