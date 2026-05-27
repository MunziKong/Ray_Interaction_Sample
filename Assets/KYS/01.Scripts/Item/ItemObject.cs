using UnityEngine;

// 씬에 배치되는 아이템 오브젝트에 부착하는 컴포넌트
[RequireComponent(typeof(Collider))]
public class ItemObject : MonoBehaviour
{
    // 이 오브젝트가 참조하는 아이템 데이터
    [SerializeField] private ItemData itemData;

    public ItemData Data => itemData;

    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
