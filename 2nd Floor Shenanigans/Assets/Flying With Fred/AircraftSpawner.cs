using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftSpawner : MonoBehaviour
{
    public GameObject[] planes;
    public GameObject[] rockets;
    public float initialPeriod;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int type;
        int selection;
        timer += Time.deltaTime;
        if(timer > initialPeriod)
        {
            type = Random.Range(0, 10);
            if(type > 3)
            {
                selection = Random.Range(0, 12);
                Instantiate(planes[selection]);
            }
            else
            {
                selection = Random.Range(0, 5);
                Instantiate(rockets[selection]);
            }
            if(initialPeriod > 2)
            {
                initialPeriod -= 0.2f;
            }
            ResetTimer();
        }
    }

    public void ResetTimer()
    {
        timer = 0;
    }
}
