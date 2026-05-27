using UnityEngine;

// 아이템 타입 열거형
public enum ItemType
{
    Potion,
    Weapon,
    Food
}

[CreateAssetMenu(fileName = "NewItem", menuName = "KYS/Item/ItemData")]
public class ItemData : ScriptableObject
{
    // 아이템 이름
    public string itemName;

    // 아이템 설명
    [TextArea(2, 5)]
    public string description;

    // 아이템 타입 (포션, 무기, 음식)
    public ItemType itemType;

    // 획득 가능 여부
    public bool isObtainable;

    // 인벤토리에 표시할 아이콘
    public Sprite icon;
}
