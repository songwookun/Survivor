using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Scriptble Object/ItemData")]
public class itemData : ScriptableObject
{
    public enum itemType { Melee, Range, Glove, shoe, Heal }

    [Header("# Main Info")]
    public itemType itmeType;
    public int itemId;
    public string itemName;
    [TextArea]
    public string itemDesc;
    public Sprite itemIcon;


    [Header("# Level Data")]
    public float baseDamge;
    public int baseCount;
    public float[] damages;
    public int[] counts;

    [Header("# Weapon")]
    public GameObject projecttile;
}
