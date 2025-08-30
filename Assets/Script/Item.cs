using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public itemData data;
    public int level;
    public Weapon weapon;
    public Gear gear;

    Image icon;
    Text textLevel;
    Text textName;
    Text textDesc;

    private void Awake()
    {
        var imgs = GetComponentsInChildren<Image>();
        if (imgs != null && imgs.Length > 1)
        {
            icon = imgs[1];
            if (data != null && data.itemIcon != null)
                icon.sprite = data.itemIcon;
        }

        Text[] texts = GetComponentsInChildren<Text>();
        if (texts != null && texts.Length > 0) textLevel = texts[0];
        if (texts != null && texts.Length > 1) textName = texts[1];
        if (texts != null && texts.Length > 2) textDesc = texts[2];

        if (textName != null && data != null)
            textName.text = data.itemName;
    }

    private void OnEnable()
    {
        if (textLevel != null)
            textLevel.text = "Lv." + (level + 1);

        if (data == null || textDesc == null) return;

        int dmgLen = data.damages != null ? data.damages.Length : 0;
        int cntLen = data.counts != null ? data.counts.Length : 0;
        int idx = (dmgLen > 0) ? Mathf.Clamp(level, 0, dmgLen - 1) : 0;

        switch (data.itmeType) 
        {
            case itemData.itemType.Melee:
            case itemData.itemType.Range:
                {
                    float dmg = (dmgLen > 0) ? data.damages[idx] * 100f : 0f;
                    int cnt = (cntLen > idx) ? data.counts[idx] : 0;
                    textDesc.text = string.Format(data.itemDesc, dmg, cnt);
                    break;
                }
            case itemData.itemType.Glove:
            case itemData.itemType.shoe:
                {
                    float rate = (dmgLen > 0) ? data.damages[idx] * 100f : 0f;
                    textDesc.text = string.Format(data.itemDesc, rate);
                    break;
                }
            default:
                textDesc.text = string.Format(data.itemDesc);
                break;
        }
    }

    public void OnClick()
    {
        if (data == null) return;

        int dmgLen = data.damages != null ? data.damages.Length : 0;
        int cntLen = data.counts != null ? data.counts.Length : 0;
        int idx = (dmgLen > 0) ? Mathf.Clamp(level, 0, dmgLen - 1) : 0;

        switch (data.itmeType) 
        {
            case itemData.itemType.Melee:
            case itemData.itemType.Range:
                if (level == 0)
                {
                    GameObject newWeapon = new GameObject("Weapon");
                    weapon = newWeapon.AddComponent<Weapon>();
                    weapon.Init(data);
                }
                else
                {
                    float nextDamage = data.baseDamge;
                    int nextCount = 0;

                    if (dmgLen > 0)
                        nextDamage += data.baseDamge * data.damages[idx];
                    if (cntLen > idx)
                        nextCount += data.counts[idx];

                    if (weapon != null)
                        weapon.LevelUp(nextDamage, nextCount);
                }
                break;

            case itemData.itemType.Glove:
            case itemData.itemType.shoe:
                if (level == 0)
                {
                    GameObject newGear = new GameObject("Gear");
                    gear = newGear.AddComponent<Gear>();
                    gear.Init(data);
                }
                else
                {
                    float nextRate = (dmgLen > 0) ? data.damages[idx] : 0f;
                    if (gear != null)
                        gear.LevelUp(nextRate);
                }
                break;

            case itemData.itemType.Heal:
                GameManager.Instance.health = GameManager.Instance.maxHealth;
                break;
        }

        level++;

        if (dmgLen > 0 && level >= dmgLen)
        {
            var btn = GetComponent<Button>();
            if (btn != null) btn.interactable = false;
        }

        if (textLevel != null)
            textLevel.text = "Lv." + (level + 1);
    }
}
