using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man03 : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
      animator.SetBool("fly back death", true);
    }

    // Update is called once per frame
    void Update()
    {
        
            
        
    }
}
