using UnityEngine;

[CreateAssetMenu(fileName = "ItemSet", menuName = "SO/LevelUp Item Set")]
public class ItemSet : ScriptableObject
{
    public itemData[] options = new itemData[5];
}
