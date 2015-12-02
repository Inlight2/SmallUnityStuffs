using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour {

	[SerializeField] Button TakeResButton;
	[SerializeField] Button PutBackResButton;

	[SerializeField] Button AddMaxButton;
	[SerializeField] Button SubMaxButton;
	[SerializeField] Button ClearAllButton;

	const int INIT_RESERVES = 10;
	const int INIT_MAX = 10;

	int unassignedPool;
	int reserve;

	void Start() {
		unassignedPool = INIT_MAX;
		reserve = INIT_RESERVES;
	}
}
