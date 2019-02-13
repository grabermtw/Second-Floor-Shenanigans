using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTimer : MonoBehaviour
{
    public float timeLeft;
    public float explosionRadius;

    private bool hitPlayer = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Collider other in Physics.OverlapSphere(transform.position, explosionRadius))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!hitPlayer && other.gameObject.GetComponent<Light>().enabled == true)
                {
                    other.gameObject.GetComponent<ShieldManager>().LowerLevel();
                    hitPlayer = true;
                }
                else if(!hitPlayer && other.gameObject.GetComponent<Light>().enabled == false)
                {
                    other.GetComponent<EmScore>().GameOver();
                    other.gameObject.GetComponent<Rigidbody>().useGravity = true;
                    other.gameObject.GetComponent<Rigidbody>().AddExplosionForce(1500, transform.position, explosionRadius);
                    GameObject.Find("Terrain").GetComponent<TerrainCollider>().enabled = true;
                    other.gameObject.GetComponent<EmMovement>().enabled = false;
                }
            }
        }
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }
}
