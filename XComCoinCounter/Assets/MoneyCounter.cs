using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MoneyCounter : MonoBehaviour {

	[SerializeField] GameObject coinPrefab;

	[SerializeField] Button takeResButton;
	[SerializeField] Button putBackResButton;

	[SerializeField] Button addMaxButton;
	[SerializeField] Button subMaxButton;
	[SerializeField] Button clearAllButton;

	public static MoneyCounter masterCounter;

	const int INIT_RESERVES = 10;
	const int INIT_MAX = 10;

	const int X_SPACING = 36;
	const int Y_SPACING = 30;

	int unassignedPool;
	int reserve;

	List<GameObject> coins = new List<GameObject>();

	void Start() {
		masterCounter = this;
		unassignedPool = INIT_MAX;
		reserve = INIT_RESERVES;
		while (!UpdateVisual()) {}
	}

	bool UpdateVisual(){
		if (coins.Count > reserve) {
			GameObject coin = coins [coins.Count - 1];
			coins.Remove (coin);
			Destroy (coin);
		} else if (coins.Count < reserve) {
			GameObject coin = Instantiate<GameObject> (coinPrefab);
			coins.Add (coin);
			int y = (int)Mathf.Ceil (reserve / 10);
			int x = (reserve - 1) % 10;
			x++;
			coin.transform.localPosition = new Vector3 (X_SPACING * x, Y_SPACING * y, 0);
		} else {
			return false;
		}
		return true;
	}

	/// <summary>
	/// Takes a coin from the master Counter.
	/// </summary>
	/// <returns><c>true</c>, if coin was taken, <c>false</c> otherwise.</returns>
	public bool TakeCoin(){
		if (reserve > 0) {
			reserve--;
			UpdateVisual();
			return true;
		} else {
			return false;
		}
	}

	/// <summary>
	/// Gives a Coin to the master counter
	/// </summary>
	/// <returns><c>true</c>, if coin was given, <c>false</c> otherwise.</returns>
	public bool GiveCoin(){
		reserve ++;
		UpdateVisual ();
		return true;
	}
}
