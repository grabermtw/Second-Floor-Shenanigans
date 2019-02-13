using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rain : MonoBehaviour {

    public GameObject money;
    public float period = 1.0f;
    private float time = 0.0f;
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if(time > period)
        {
            time = 0.0f;
            Instantiate(money, new Vector3(Random.Range(-9f, 9f), 8, 0), Random.rotation);
            if (period > 0.002f)
            {
                period -= 0.002f;
            }
            Debug.Log(period);
        }
        
       
	}

    public void ResetPeriod()
    {
        period = 1.0f;
    }
}
