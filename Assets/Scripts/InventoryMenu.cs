using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour {

	public GameObject Panel;
	public bool inventoryOpen = false;

	public void showHideInventory (){
		if(inventoryOpen){
			inventoryOpen = false;
			Panel.gameObject.SetActive (false);
		}else{
			inventoryOpen = true;
			Panel.gameObject.SetActive (true);
		}
	}

	// Use this for initialization
	void Start () {
		Panel.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
