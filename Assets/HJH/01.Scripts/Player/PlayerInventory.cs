using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventory : MonoBehaviour
{
    private List<Slot> _slots = new List<Slot>();
    public List<Slot> Slots => _slots;
    public event Action OnInventoryChanged;
    public event Action ToggleInventoryUIEvent;

    void Start()
    {
        OnInventoryChanged?.Invoke();
    }

    void Update()
    {
        ToggleInventoryUI();
    }
    
    void ToggleInventoryUI()
    {
        if (Keyboard.current.iKey.wasPressedThisFrame)
        {
            ToggleInventoryUIEvent?.Invoke();
        }
    }

    public void AddItem(ItemData itemData)
    {
        for (int i = 0; i < _slots.Count; i++)
        {
            if (_slots[i].itemData.itemName == itemData.itemName)
            {
                _slots[i].amount += 1;

                OnInventoryChanged?.Invoke();
                return;
            }
        }

        Slot newSlot = new Slot
        {
            itemData = itemData,
            amount = 1
        };

        _slots.Add(newSlot);
        OnInventoryChanged?.Invoke();
    }
}
