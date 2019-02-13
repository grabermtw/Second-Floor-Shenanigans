using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public float period;
    public GameObject meteor;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        Instantiate(meteor);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= period)
        {
            Instantiate(meteor);
            timer = 0;
            if (period > 1)
            {
                period -= 0.15f;
            }
        }

    }
}
