using TMPro;
using UnityEngine;

// 아이템 정보를 표시하는 UI 패널 컨트롤러 — Canvas 하위 Panel에 부착
public class ItemDescriptionUI : MonoBehaviour
{
    // 아이템 정보를 표시할 패널 루트 오브젝트
    [SerializeField] private GameObject panel;

    // 아이템 이름 텍스트
    [SerializeField] private TMP_Text itemNameText;

    // 아이템 타입 텍스트
    [SerializeField] private TMP_Text itemTypeText;

    // 아이템 설명 텍스트
    [SerializeField] private TMP_Text descriptionText;

    // 획득 안내 텍스트 ("Press E to pick up" 등)
    [SerializeField] private TMP_Text interactPromptText;

    private void Awake()
    {
        panel.SetActive(false);
    }

    public void Show(ItemData data)
    {
        itemNameText.text = data.itemName;
        itemTypeText.text = data.itemType.ToString();
        descriptionText.text = data.description;
        interactPromptText.text = data.isObtainable ? "Press E to pick up" : "Cannot obtain";
        interactPromptText.color = data.isObtainable ? Color.white : Color.gray;

        panel.SetActive(true);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
}
