using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    List<GameObject> placeList;
    List<GameObject> itemList;
    Transform inventoryBg;
    GameObject itemDesc;
    GameObject from = null;
    GameObject lastSlot = null;
    GameObject equipButton, unequipButton;
    public GameObject player, playerShow;
    List<Character> chars;
    bool usingHelmet;
    public Texture2D helmetTexture;
    bool hideHelmet = false;


    SpriteCollection sc;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform.Find("Dummy").gameObject;
        playerShow = transform.Find("CharacterShow").Find("DummyShow").gameObject;
        itemDesc = transform.Find("ItemDesc").gameObject;
        equipButton = itemDesc.transform.Find("EquipButton").gameObject;
        unequipButton = itemDesc.transform.Find("UnequipButton").gameObject;
        inventoryBg = transform.Find("InventoryBg");
        itemList = GameObject.Find("ItemManager").GetComponent<ItemManagerController>().itemList;
        placeList = new List<GameObject>();
        sc = GameObject.Find("GameMananger").GetComponent<SpriteCollection>();
        foreach (Transform t in inventoryBg)
        {
            placeList.Add(t.gameObject);
        }

        chars = new List<Character>();
        chars.Add(player.GetComponent<Character>());
        chars.Add(playerShow.GetComponent<Character>());
        helmetTexture = null;
        fillInventory();
        equipInPlayer();
        checkHelmet();

        setItem("I2", 3);
        setItem("I3", 7);
        setItem("I4", 6);
    }

    public void equipInPlayer()
    {
        GameObject[] Dummies = GameObject.FindGameObjectsWithTag("Dummy");
        foreach (Character ch in chars)
        {
            foreach (GameObject g in placeList)
            {
                if (g.GetComponent<Slot>().type == "i")
                    break;

                if (g.name == "Hand")
                {
                    if (g.GetComponent<Slot>().item == null)
                        ch.Weapon = null;
                    else
                        ch.Weapon = g.GetComponent<Slot>().item.GetComponent<ItemController>().textureImage;

                }
                if (g.name == "Helmet")
                {
                    if (g.GetComponent<Slot>().item == null)
                        ch.Helmet = null;
                    else
                        ch.Helmet = g.GetComponent<Slot>().item.GetComponent<ItemController>().textureImage;
                    toggleHelmet();
                    checkHelmet();
                    
                }
                if (g.name == "Armor")
                {
                    if (g.GetComponent<Slot>().item == null)
                        ch.Armor = null;
                    else
                        ch.Armor = g.GetComponent<Slot>().item.GetComponent<ItemController>().textureImage;
                }
                if (g.name == "OffHand")
                {
                    if (g.GetComponent<Slot>().item == null)
                        ch.Shield = null;
                    else
                        ch.Shield = g.GetComponent<Slot>().item.GetComponent<ItemController>().textureImage;
                }
            }
            ch.Initialize();
            checkHelmet();
        }

    }
    public void fillInventory()
    {
        foreach (GameObject g in placeList)
        {
            if (PlayerPrefs.GetInt(g.name) > 0)
            {
                setItem(g.name, PlayerPrefs.GetInt(g.name));
                g.GetComponent<Slot>().adjustSprite();
            }
        }
    }
    public void setItem(string place, int code)
    {
        GameObject slot = null;
        PlayerPrefs.SetInt(place, code);
        foreach (GameObject g in placeList)
        {
            if (g.name == place)
            {
                slot = g;
                slot.GetComponent<Slot>().item = getSystemItem(code);
                break;
            }
        }
        slot.transform.Find("Img").GetComponent<Image>().sprite = slot.GetComponent<Slot>().item.GetComponent<ItemController>().image;
        slot.transform.Find("Img").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
    public void setItem(GameObject slot, GameObject item)
    {
        PlayerPrefs.SetInt(slot.name, item.GetComponent<ItemController>().code);
        slot.GetComponent<Slot>().item = item;
        slot.transform.Find("Img").GetComponent<Image>().sprite = item.GetComponent<ItemController>().image;
        slot.transform.Find("Img").GetComponent<Image>().color = new Color32(255, 255, 255, 255);

    }

    public void removeItem(string place)
    {
        foreach (GameObject g in placeList)
        {
            if (g.name == place)
            {
                PlayerPrefs.SetInt(place, 0);
                g.GetComponent<Slot>().item = null;
                g.transform.Find("Img").GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;
            }
        }
    }
    //returns an item with the id passed as parameter
    public GameObject getSystemItem(int code)
    {
        foreach (GameObject g in itemList)
        {
            if (g.GetComponent<ItemController>().code == code)
                return g;
        }
        return null;
    }

    public void equipItem()
    {
        if (from == null)
            return;
        GameObject helmet = null, hand = null, armor = null, offHand = null;
        foreach (GameObject g in placeList)
        {
            if (g.name == "Helmet")
                helmet = g;
            if (g.name == "Hand")
                hand = g;
            if (g.name == "Armor")
                armor = g;
            if (g.name == "OffHand")
            {
                offHand = g;
            }
        }


        if (from.GetComponent<Slot>().item.GetComponent<ItemController>().type == "1H" || from.GetComponent<Slot>().item.GetComponent<ItemController>().type == "2H")
        {
            if (isFull(hand))
            {
                GameObject tempItem = hand.GetComponent<Slot>().item;
                removeItem(hand);
                changeItem(from, hand);
                setItem(from, tempItem);
            }
            else
            {
                changeItem(from, hand);

            }
            from = hand;
            showItem(from);

        }

        if (from.GetComponent<Slot>().item.GetComponent<ItemController>().type == "Helmet")
        {
            if (isFull(helmet))
            {
                GameObject tempItem = helmet.GetComponent<Slot>().item;
                removeItem(helmet);
                changeItem(from, helmet);
                setItem(from, tempItem);
            }
            else
            {
                changeItem(from, helmet);

            }
            from = helmet;
            showItem(from);

        }

        if (from.GetComponent<Slot>().item.GetComponent<ItemController>().type == "Armor")
        {
            if (isFull(armor))
            {
                GameObject tempItem = armor.GetComponent<Slot>().item;
                removeItem(armor);
                changeItem(from, armor);
                setItem(from, tempItem);
            }
            else
            {
                changeItem(from, armor);

            }
            from = armor;
            showItem(from);

        }
        if (from.GetComponent<Slot>().item.GetComponent<ItemController>().type == "Shield")
        {

            if (isFull(offHand))
            {
                GameObject tempItem = offHand.GetComponent<Slot>().item;
                removeItem(offHand);
                changeItem(from, offHand);
                setItem(from, tempItem);
            }
            else
            {
                changeItem(from, offHand);

            }
            from = offHand;
            showItem(from);

        }
        equipInPlayer();
    }
    public bool isFull(GameObject slot)
    {
        return (slot.GetComponent<Slot>().item != null);
    }
    public GameObject findEmptySlot()
    {
        for (int i = 4; i < placeList.Count; i++)
        {
            if (placeList[i].GetComponent<Slot>().item == null)
            {
                return placeList[i];
            }
        }
        return null;
    }
    public void changeItem(GameObject from, GameObject to)
    {
        setItem(to, from.GetComponent<Slot>().item);
        removeItem(from);
        from.GetComponent<Slot>().adjustSprite();
        to.GetComponent<Slot>().adjustSprite();

    }
    void removeItem(GameObject slot)
    {
        slot.GetComponent<Slot>().item = null;
        slot.transform.Find("Img").GetComponent<Image>().sprite = null;
        slot.transform.Find("Img").GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        PlayerPrefs.SetInt(slot.name, 0);
    }
    public void removeEquipedItem()
    {
        from = null;
        removeItem(lastSlot);
        itemDesc.transform.Find("Title").GetComponentInChildren<Text>().text = "";
        itemDesc.transform.Find("ItemImage").GetComponent<Image>().sprite = null;
        itemDesc.transform.Find("ItemImage").GetComponent<Image>().color = new Color(0, 0, 0, 0);
        itemDesc.transform.Find("Damage").GetComponent<Text>().text = "";
        equipInPlayer();
    }

    public void unequipItem()
    {
        GameObject emptySlot = findEmptySlot();
        if (emptySlot == null)
        {
            print("Inventory is full");
            return;
        }
        changeItem(from, emptySlot);
        from = emptySlot;
        showItem(from);
        equipInPlayer();

    }
    public void showItem(GameObject g)
    {
        if (g.GetComponent<Slot>().item == null)
            return;
        lastSlot = g;
        from = g;
        itemDesc.transform.Find("Title").GetComponentInChildren<Text>().text = g.GetComponent<Slot>().item.GetComponent<ItemController>().name;
        itemDesc.transform.Find("ItemImage").GetComponent<Image>().sprite = g.GetComponent<Slot>().item.GetComponent<ItemController>().image;
        itemDesc.transform.Find("ItemImage").GetComponent<Image>().color = new Color(255, 255, 255, 255);
        itemDesc.transform.Find("Damage").GetComponent<Text>().text = "Damage  " + g.GetComponent<Slot>().item.GetComponent<ItemController>().iDamage.ToString() +
            " ~ " + g.GetComponent<Slot>().item.GetComponent<ItemController>().fDamage.ToString();
        if (g.GetComponent<Slot>().type == "s")
        {
            equipButton.SetActive(false);
            unequipButton.SetActive(true);
        }
        else
        {
            equipButton.SetActive(true);
            unequipButton.SetActive(false);
        }
    }

    public void checkHelmet()
    {
        var helmet = placeList[0];
        if (helmet.GetComponent<Slot>().item == null || player.GetComponent<Character>().Helmet == null)
        {
            toggleHair("b");
        }
        else
        {
            toggleHair("s");
        }
    }


    public void toggleHair(string type)
    {
        if (type == "b")
        {
            var index = sc.HairShort.FindIndex(playerhair => playerhair.name == player.GetComponent<Character>().Hair.name);
            player.GetComponent<Character>().Hair = sc.Hair[index];
            playerShow.GetComponent<Character>().Hair = sc.Hair[index];
            print("big");
        }
        else
        {
            var index = sc.Hair.FindIndex(playerhair => playerhair.name == player.GetComponent<Character>().Hair.name);
            player.GetComponent<Character>().Hair = sc.HairShort[index];
            playerShow.GetComponent<Character>().Hair = sc.HairShort[index];

        }
        player.GetComponent<Character>().Initialize();
        playerShow.GetComponent<Character>().Initialize();
    }



    public void toggleHelmet()
    {
        var helmet = placeList[0];
        if (helmet.GetComponent<Slot>().item != null)
        {
            print(GameObject.Find("HideHelmet").GetComponent<Toggle>().isOn);
            if (!GameObject.Find("HideHelmet").GetComponent<Toggle>().isOn)
            {
                helmetTexture = player.GetComponent<Character>().Helmet;
                player.GetComponent<Character>().Helmet = null;
                playerShow.GetComponent<Character>().Helmet = null;
            }
            else
            {
                if (helmetTexture != null)
                {
                    player.GetComponent<Character>().Helmet = helmetTexture;
                    playerShow.GetComponent<Character>().Helmet = helmetTexture;
                    helmetTexture = null;
                }
            }
            player.GetComponent<Character>().Initialize();
            playerShow.GetComponent<Character>().Initialize();
            checkHelmet();
        }
    }
}
