using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region singleton
    public static InventoryUI instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    #endregion

    private bool inventoryOpen = false; // Bool p/ inventário aberto ou fechado
    public bool InventoryOpen => inventoryOpen;

    public PassiveManager PassiveM;
    public GameObject inventoryScreen; // GUI do Inventário
    public GameObject inventoryTab; // Aba Inventario
    public GameObject craftingTab; // Aba Craft
    public GameObject passivaTab; // Aba Passiva
    public GameObject passivaGUI; // Painel de passivas
    public GameObject itemSlotPrefab;
    public Transform inventoryItemTransform;
    
    public Transform craftingItemTransform;


    private void Start()
    {
        InventoryManager.instance.onItemChange += UpdateInventoryUI;
        UpdateInventoryUI();
        SetupCraftingRecipes();
    }
    
    void Update() // Abrir e fechar inventário
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryOpen)
            {
                CloseInventory();
            } else {
                OpenInventory();
            }
        }
    }

    private void SetupCraftingRecipes()
    {

    }

    private void UpdateInventoryUI() // Adiciona os items novos no slot
    {
        int itemCount = InventoryManager.instance.itemsList.Count;
        
        
    }

    private void AddItemSlots(int itemCount) // Adiciona mais items nos slots do invetário
    {
        
    }

    private void OpenInventory() // Ao pressionar a tecla "i", o inventario abre
    {
        inventoryOpen = true;
        inventoryScreen.SetActive(true);
    }
    
    private void CloseInventory() // Ao pressionar a tecla "i", o inventario fecha
    {
        inventoryOpen = false;
        inventoryScreen.SetActive(false);
    }

    // Alternar entre as abas de invetário e crafting
    public void OnCraftingTabClicked()
    {
        craftingTab.SetActive(true);
        inventoryTab.SetActive(false);
        passivaTab.SetActive(false);
        passivaGUI.SetActive(false);
    }
    
    public void OnInventoryTabClicked()
    {
        craftingTab.SetActive(false);
        inventoryTab.SetActive(true);
        passivaTab.SetActive(false);
        passivaGUI.SetActive(false);
    }

    public void onPassivaTabClicked()
    {
        //craftingTab.SetActive(false);
       // inventoryTab.SetActive(false);
       // passivaTab.SetActive(true);
        
        if (!craftingTab.activeSelf)
        {
            PassiveM.OpenPainel();
            passivaGUI.SetActive(true);
        }
    }

    // P/ travar o cursor do player e não atrapalhar no mapa
    // private void ChangeCursorState(bool lockCursor)
    // {
    //     if (lockCursor)
    //     {
    //         Cursor.lockState = CursorLockMode.Locked;
    //         Cursor.visible = false;
    //     }
    //     else {
    //         Cursor.lockState = CursorLockMode.None;
    //         Cursor.visible = true;
    //     }
    // }
}
