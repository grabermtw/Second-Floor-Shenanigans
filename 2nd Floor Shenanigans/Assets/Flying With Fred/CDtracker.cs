using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDtracker : MonoBehaviour
{
    public Transform cd;
    public Transform fred;
    private Vector3 v_diff;
    private float atan2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        v_diff = (cd.position - fred.position);
        atan2 = Mathf.Atan2(v_diff.y, v_diff.x);
        transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg);
    }
}
