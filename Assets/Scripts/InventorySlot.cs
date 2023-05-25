using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour
{

    //public static event Action<InventorySlot> selectSlot;
    public static List<InventorySlot> selectedSlots = new List<InventorySlot>();
    public static int numSelected = 0;
    public static bool isCombining = false;

    public Image icon;
    public TextMeshProUGUI labelText;
    private bool minimized;
    private Image background;
    public bool selected = false;
    public Button button;
    public GameObject menuPrefab;
    Vector3 mini;
    Vector3 max;

    //public TextMeshProUGUI stackSizeText;

    // Start is called before the first frame update

    private void Start() {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
        //button.isPointerOver.AddListener(HoverOver);
        background =  gameObject.GetComponent<Image>();
    }
    public void HoverOver() {
        //Debug.Log("Hovering Over");
    }
    void TaskOnClick(){
        background =  gameObject.GetComponent<Image>();
        GameObject menu = null;
        if(!selected)
        {
            // need to clean up
            if(numSelected == 0) {
                menu = Instantiate(menuPrefab);
                menu.transform.SetParent(transform,false);
            }
            if(numSelected == 0|| isCombining ) {
                numSelected += 1;
                selectedSlots.Add(this);
                selected = true;
            } 
            else {
                foreach(InventorySlot slot in selectedSlots) {
                    slot.selected= false;
                }
                numSelected = 0;
                selectedSlots.Clear();
                CleanMenus();
                selectedSlots.Add(this);
                menu = Instantiate(menuPrefab);
                menu.transform.SetParent(transform,false);
                numSelected += 1;
                selected = true;
            }
        }
        else {
            CleanMenus();
            Debug.Log("Destroying");
            isCombining = false;
            selected = false;
            numSelected -=1;
            selectedSlots.Remove(this);

        }
        Debug.Log("Inventory Clicked");
    }


    void Combine(){

        
    }


    void Update() {
        if(selected) {
            background.color = Color.blue;
        }
        if(!selected) {
            
            background.color = Color.gray;
        }
    }
    void CleanMenus() {
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Menu")){
                Debug.Log(go);
                Destroy(go);
            }
    }
    

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        selected = false;
       // stackSizeText.enabled = false;
    }

    public void DrawSlot(InventoryItem item) {
        if(item == null)
        {
            ClearSlot();
            return;
        }
        //button = gameObject.GetComponent<Button>();
        //button.onClick.AddListener(TaskOnClick);
        icon.enabled = true;
        labelText.enabled = true;
        
        icon.sprite = item.itemData.icon;
        labelText.text = item.itemData.displayName;

        
    }
    

}
