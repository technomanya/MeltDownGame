using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : UnitBaseBehaviour
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
        if(state == UnitStates.OnPlatform)
        {
            if(Input.GetKeyDown(KeyCode.W))
                Jump();
            if (Input.GetKey(KeyCode.S))
                Shrink();
        }
        else if(state == UnitStates.Shrinked)
        {
            if(Input.GetKeyUp(KeyCode.S))
            {
                Enlarge();
            }
        }

        
    }
}
