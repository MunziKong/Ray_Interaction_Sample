using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _inventoryPanel;

    [SerializeField] private PlayerInventory _inventory;
    [SerializeField] private GameObject _slotsWrap;
    [SerializeField] private bool _isOpened = false;

    private SlotUI[] _slotUIs;

    public bool IsOpened => _isOpened;
    


    void Awake()
    {
        _slotUIs = _slotsWrap.GetComponentsInChildren<SlotUI>();
    }

    void OnEnable()
    {
        _inventory.OnInventoryChanged += UpdateInventoryUI;
        _inventory.ToggleInventoryUIEvent += ToggleInventory;
    }

    void OnDisable()
    {
        _inventory.OnInventoryChanged -= UpdateInventoryUI;
        _inventory.ToggleInventoryUIEvent -= ToggleInventory;
    }

    public void OpenInventory()
    {
        if (_isOpened)
            return;

        _isOpened = true;
        _inventoryPanel.SetActive(true);
        UpdateInventoryUI();
    }

    public void CloseInventory()
    {
        if (!_isOpened)
            return;

        _isOpened = false;
        _inventoryPanel.SetActive(false);
    }

    public void ToggleInventory()
    {
        if (_isOpened)
        {
            CloseInventory();
        }
        else
        {
            OpenInventory();
        }
    }

    void UpdateInventoryUI()
    {
        List<Slot> slots = _inventory.Slots;

        for (int i = 0; i < _slotUIs.Length; i++)
        {
            if (i < slots.Count && slots[i].amount > 0)
            {
                _slotUIs[i].SetSlot(slots[i]);
            }
            else
            {
                _slotUIs[i].ClearSlot();
            }
        }
    }

    
}