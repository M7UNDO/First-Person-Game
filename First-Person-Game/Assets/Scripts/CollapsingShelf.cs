using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingShelf : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        
    }

    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision coli)
    {
        if (coli.gameObject.CompareTag("Bullet"))
        {
            rb.useGravity = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
