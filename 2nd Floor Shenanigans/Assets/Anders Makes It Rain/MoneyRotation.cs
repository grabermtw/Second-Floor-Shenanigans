using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRotation : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Random.rotation.eulerAngles / 50f);
	}
}
