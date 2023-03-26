using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitorBehaviour : UnitBaseBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        defaultSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
