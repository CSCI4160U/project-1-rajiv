using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class InventoryData
{
    public Equipment armour;
    public Equipment weapon;
    public List<Equipment> unequipped = new List<Equipment>();
}
