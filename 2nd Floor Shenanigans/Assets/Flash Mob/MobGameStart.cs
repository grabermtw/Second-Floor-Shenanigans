using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGameStart : MonoBehaviour
{
    public GameObject title;
    public GameObject premise;
    public GameObject instructions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (title.activeSelf)
            {
                title.SetActive(false);
            }
            else if (premise.activeSelf)
            {
                premise.SetActive(false);
            }
            else
            {
                instructions.SetActive(false);
                GetComponent<ScatterPeople>().enabled = true;
                this.enabled = false;
            }
        }
    }
}
