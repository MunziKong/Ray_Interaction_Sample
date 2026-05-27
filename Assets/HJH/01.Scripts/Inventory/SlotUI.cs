using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _amount;


    public void SetSlot(Slot slot)
    {
        _icon.sprite = slot.itemData.icon;
        _icon.gameObject.SetActive(true);

        _amount.text = slot.amount.ToString();
        _amount.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        _icon.sprite = null;
        _icon.gameObject.SetActive(false);

        _amount.text = "";
        _amount.gameObject.SetActive(false);
    }

}