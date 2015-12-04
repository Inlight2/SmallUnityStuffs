using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UsedCoins : MonoBehaviour {

	[SerializeField] GameObject originCoin;

	[SerializeField] Button takeCoinButton;
	[SerializeField] Button returnCoinButton;

	int coinCount = 0;

	const int X_DELTA = 10;
	const int Y_DELTA = 10;

	List<GameObject> coins = new List<GameObject>();

	void Start() {
		takeCoinButton.onClick.AddListener(delegate{TakeCoin();});
		returnCoinButton.onClick.AddListener(delegate {ReturnCoin ();});
	}

	void TakeCoin() {
		if (MoneyCounter.masterCounter.TakeCoin ()) {
			coinCount ++;
			int x = (coinCount-1) % 2;
			int y = (int)Mathf.Floor( coinCount / 2);
			GameObject coin = Instantiate<GameObject>(originCoin);
			coin.transform.localPosition = new Vector3(originCoin.transform.localPosition.x + x * X_DELTA,
			                                           originCoin.transform.localPosition.y + y * Y_DELTA,
			                                           originCoin.transform.localPosition.z);
			coins.Add(coin);
		}
	}

	void ReturnCoin() {
		if (coinCount > 0) {
			MoneyCounter.masterCounter.GiveCoin ();
			coinCount --;
			GameObject coin = coins[coins.Count -1];
			coins.Remove(coin);
			Destroy(coin);
		}
	}
}
