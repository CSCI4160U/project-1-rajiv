using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Equipment armour;
    public Equipment weapon;
    public List<Equipment> unequipped = new List<Equipment>();
    private const int maxUnequippedSize = 4;
    private Player player;

    private void Start()
    {
        player = this.GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the item is loot
        if(collision.CompareTag("Loot"))
        {
            Equipment newItem = collision.gameObject.GetComponent<Equipment>();
            // add item being collected to the unequipped list

            if(unequipped.Count == maxUnequippedSize)
            {
                Debug.Log("Inventory is Full");
            }
            else if (newItem != null && !unequipped.Contains(newItem))
            {
                // pick up the item
                unequipped.Add(newItem);

                // make item despawn
                newItem.gameObject.SetActive(false);

                Debug.Log("'" + newItem.description + "' of type '" + newItem.type + "' was added to inventory (unequipped) ");
            }
        }
    }

    private void Update()
    {
        PopulatUnequippedInventory();
        UpdatePlayerArmorAndDefense();
    }

    private void UpdatePlayerArmorAndDefense()
    {
        if (player != null)
        {
            if(weapon != null)
            {
                player.SetAttackPower(player.defaultAttack + weapon.attack);
                Debug.Log("Player Attack Boosted");
            }
            else
            {
                player.SetAttackPower(player.defaultAttack);
            }

            if (armour != null)
            {
                player.SetDefense(player.defaultDefense + armour.defense);
                Debug.Log("Player Defense Boosted");
            }
            else
            {
                player.SetDefense(player.defaultDefense);
            }
        }
    }

    // replaces the values of the Equipment component in a gameObject
    private void InitializeEquipmentForGameObject(GameObject obj, Equipment e)
    {
        if(obj.GetComponent<Equipment>() == null)
        {
            obj.AddComponent<Equipment>();
        }
        obj.GetComponent<Image>().sprite = e.icon;
        obj.GetComponent<Equipment>().attack = e.attack;
        obj.GetComponent<Equipment>().defense = e.defense;
        obj.GetComponent<Equipment>().description = e.description;
        obj.GetComponent<Equipment>().type = e.type;
        obj.GetComponent<Equipment>().icon = e.icon;
    }

    // fills in the unequipped inventory based on the list of unequipped items
    private void PopulatUnequippedInventory()
    {
        GameObject unequippedItems = GameObject.Find("UnequippedItems");
        //Debug.Log("Length: "+numUnequippedItems);
        for (int i = 0; i < unequipped.Count; i++)
        {
            GameObject unequippedItemButton = unequippedItems.transform.GetChild(i).gameObject;

            if(unequipped[i] != null)
            {
                GameObject objectCollected = unequippedItemButton.transform.GetChild(0).gameObject;
             
                // Adding new values of equipment
                InitializeEquipmentForGameObject(objectCollected, unequipped[i]);
            }
            

            //this.gameObject.transform.GetChild(i).gameObject.GetComponent<Button>().image.sprite = Inventory.unequipped[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    // Unequip a piece of equipment from inventory button
    public void Equip(GameObject button)
    {
        Equipment equipment = button.transform.GetChild(0).gameObject.GetComponent<Equipment>();
        GameObject objectToBeEquipped = null;

        if(equipment.type == "Armour")
        {
            // equip armour
            objectToBeEquipped = GameObject.Find("EquippedArmourSprite");
            armour = equipment;
        }
        else if(equipment.type == "Weapon")
        {
            // equip weapon
            objectToBeEquipped = GameObject.Find("EquippedWeaponSprite");
            weapon = equipment;
        }

        // if object being equipped exists
        if(objectToBeEquipped != null)
        {
            InitializeEquipmentForGameObject(objectToBeEquipped, equipment);
        }
        
        Debug.Log("Equipped a " + equipment.type + " described as "+ equipment.description + ".");

    }

    // Unequip a piece of equipment from inventory button
    public void Unequip(GameObject button)
    {       

        GameObject equippedItem = button.transform.GetChild(0).gameObject;
        Equipment equipment = equippedItem.GetComponent<Equipment>();

        // reset sprite to default
        equippedItem.GetComponent<Image>().sprite = default;
        
        if (equipment.type == "Armour")
        {
            // unequip armour
            armour = null;
        }
        else if (equipment.type == "Weapon")
        {
            // unequip weapon
            weapon = null;
        }

        Debug.Log("Unequipped a " + equipment.type + " described as " + equipment.description + ".");

    }
}
