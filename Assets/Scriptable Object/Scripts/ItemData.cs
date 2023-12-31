using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum ItemType
{
    Resource,
    Equipable,
    Consumable
}

public enum CunsumableType
{
    Hunger,
    Health
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
    
public class ItemData : ScriptableObject
{
    [FormerlySerializedAs("itemName")] [Header("Info")]
    public string displayName;
    public string description;
    public ItemType itemType;
    public Sprite icon;
    public GameObject dropPrefab;
    
    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;
    
    

}
