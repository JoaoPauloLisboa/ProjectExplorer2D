using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moneySystem : MonoBehaviour {
	public int money;
	public Text displayedMoney;
	// Use this for initialization
	void Start () {
		money = 100;
		displayedMoney.text = money.ToString ();
	}
	
	// Update is called once per frame
	void Update () {}

	public void addMoney(int moneyToAdd){
		money += moneyToAdd;
		displayedMoney.text = money.ToString ();
	}

	public void subtractMoney(int moneyToSubtract){
		if(money - moneyToSubtract < 0){
			Debug.Log ("Sem dinheiro suficiente");
		}else{
			money -= moneyToSubtract;
			displayedMoney.text = money.ToString ();
		}
	}
}
