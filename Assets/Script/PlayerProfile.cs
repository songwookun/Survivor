using UnityEngine;

[CreateAssetMenu(fileName ="PlayerProfile", menuName ="Scriptable Objects/Player Profile")]
public class PlayerProfile : ScriptableObject
{
    public string displayName;
    public RuntimeAnimatorController animator;

    [Header("Stat Multpliers")]
    public float moveSpeedMultiplier = 1f;
    public float weaponSpinSpeedMultiplier = 1f;
    public float weaponRateMultiplier = 1f;
    public float damageMultiplier = 1f;
    public int extraProjectileCount = 0;
}
