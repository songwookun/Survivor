using UnityEngine;

public class Gear : MonoBehaviour
{
    public itemData.itemType type;
    public float rate;

    public void Init(itemData data)
    {
        //Basic set
        name = "Gear " + data.itemId;
        transform.parent = GameManager.Instance.player.transform;
        transform.localPosition = Vector3.zero;

        //Property Set
        type = data.itmeType;
        rate = data.damages[0];
        ApplyGear();
    }
    public void LevelUp(float rate)
    {
        this.rate = rate;
        ApplyGear();

    }

    public void ApplyGear()
    {
        switch (type)
        {
            case itemData.itemType.Glove:
                RateUp();
                break;
            case itemData.itemType.shoe:
                SpeedUp();
                break;

        }
    }

    void RateUp()
    {
        Weapon[] wapons = transform.parent.GetComponentsInChildren<Weapon>();
        foreach (Weapon weapon in wapons)
        {
            switch (weapon.id)
            {
                case 0:
                    weapon.speed = 150 + (150 * rate);
                    break;
                default:
                    weapon.speed = 0.5f * (1f - rate);
                    break;
            }
        }
    }

    void SpeedUp()
    {
        float speed = 3;
        GameManager.Instance.player.speed = speed + speed * rate;
    }
}
