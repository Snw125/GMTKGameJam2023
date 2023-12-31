using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestUI : MonoBehaviour
{
    GameObject selectUI; 
    GameObject player;

    GameObject itemselect1;
    GameObject itemselect2;
    GameObject itemselect3;
    GameObject itemselect4;
    GameObject itemselect5;

    GameObject invUI;

    GameObject item1;
    GameObject item2;
    GameObject item3;
    GameObject item4;
    GameObject item5;

    GameObject instructions;

    List<GameObject> itemObjList;

    GameObject gameHandler;

    public ChestObj chestref;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        selectUI = transform.GetChild(2).gameObject;

        itemselect1 = selectUI.transform.GetChild(0).gameObject;
        itemselect2 = selectUI.transform.GetChild(2).gameObject;
        itemselect3 = selectUI.transform.GetChild(4).gameObject;
        itemselect4 = selectUI.transform.GetChild(6).gameObject;
        itemselect5 = selectUI.transform.GetChild(8).gameObject;

        invUI = transform.GetChild(1).gameObject;

        item1 = invUI.transform.GetChild(0).gameObject;
        item2 = invUI.transform.GetChild(1).gameObject;
        item3 = invUI.transform.GetChild(2).gameObject;
        item4 = invUI.transform.GetChild(3).gameObject;
        item5 = invUI.transform.GetChild(4).gameObject;

        instructions = selectUI.transform.GetChild(10).gameObject;
        
        itemObjList = new List<GameObject> {item1, item2, item3, item4, item5};
        
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        // Debug.Log(gameHandler);


        // ItemList.AddItem(new BasherSword());
        // ItemList.AddItem(new BasherSword());
        // ItemList.AddItem(new BasherSword());
        // ItemList.AddItem(new BasherSword());
        // ItemList.AddItem(new BasherSword());

        unhighlight();
        updateItems();
        //edit selectUI from there (what is highlighted) 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void highlightItems() 
    {   
        // highlight the right number items
        instructions.SetActive(true);

        if (ItemList.itemList.Count >= 1)  {
            itemselect1.SetActive(true);
        } 
        if (ItemList.itemList.Count >= 2) {
            itemselect2.SetActive(true);
        }
        if (ItemList.itemList.Count >= 3) {
            itemselect3.SetActive(true);
        }
        if (ItemList.itemList.Count >= 4) {
            itemselect4.SetActive(true);
        }
        if (ItemList.itemList.Count >= 5) {
            itemselect5.SetActive(true);
        }

    }

    public void unhighlight() 
    {  
        instructions.SetActive(false);
        
        itemselect1.SetActive(false);
        itemselect2.SetActive(false);
        itemselect3.SetActive(false);
        itemselect4.SetActive(false);
        itemselect5.SetActive(false);
    }

    // TODO: put in items 
    public void updateItems() 
    {
        // update item placement 
        for (int i = 0; i < ItemList.itemList.Count; i++) {
            string itemName = ItemList.itemList[i].GetName();
            // Debug.Log(i);
            // Debug.Log(itemName);
            itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = ItemList.itemList[i].GetSprite();
            // if (itemname == "Basher Sword") { 
            //     itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("2D/InventoryIcons/BusterSword");
            // } 
            // else if (itemname == "Sniper Eye") {
            //     itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("2D/InventoryIcons/Items_SniperEye");
            // }
            // else if (itemname == "Gold Coins") {
            //     itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("2D/InventoryIcons/GoldPile");
            // }
            // else if (itemname == "Lockpick") {
            //     itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("2D/InventoryIcons/Lockpick");
            // }
            // else if (itemname == "Reactor Core") {
            //     itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("2D/InventoryIcons/ReactorCore");
            // }
            // else if (itemname == "Shield of Heroes") {
            //     itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("2D/InventoryIcons/ShieldOfHeroes");
            // }
            // else if (itemname == "Staff of Villainy") {
            //     itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("2D/InventoryIcons/");
            // }
            // else if (itemname == "Winged Shoes") {
            //     itemObjList[i].transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("2D/InventoryIcons/");
            // }
        }

        for (int i = 4; i > ItemList.itemList.Count - 1; i--) {
            itemObjList[i].SetActive(false);
        }
        
    }

    public void setChestRef(ChestObj refc) {
        chestref = refc;
    }

    public void selectItem(int i)
    {
        if (chestref != null && chestref.chestOpened) {
            // Debug.Log(i + "!");
            ItemList.RemoveItem(i);
            //gameHandler = GameObject.FindGameObjectWithTag("GameHandler");
            
            // adds to gamehandler counter
            gameHandler.GetComponent<ChestTracker>().ChestFilled();

            // Debug.Log(chestref);

            chestref.chestFilled = true;
            chestref.closeChest();
        }
        
    }

    

}
