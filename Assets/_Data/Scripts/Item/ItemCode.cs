using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCode
{
    NoItem = 0,
    
    IronOre = 1,
    GoldOre = 2,

    CopperSword = 1000,
}

public class ItemCodeParse
{
    public static ItemCode FromString(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        } 
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
}