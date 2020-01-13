using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningSequenceManager : MonoBehaviour
{
    public Animator camAnim;
    public AudioSource jupiter;
    
    public GameObject johnText;
    
    // Start is called before the first frame update
    void Start()
    {
        
        camAnim.SetTrigger("OpeningSequence");
        jupiter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            johnText.SetActive(false);
            
            camAnim.SetTrigger("Skip");

        }
    }

    
}
