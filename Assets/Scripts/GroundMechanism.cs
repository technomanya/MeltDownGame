using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMechanism : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int rotationDir = 0;
    [SerializeField] Transform middlePin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        middlePin.Rotate(middlePin.transform.up, rotationDir * speed * Time.deltaTime);
    }

    public void ChangeSpeed(float _speed)
    {
        speed = _speed;
    }

    public void ChangeRotationDir(int dir)
    {
        rotationDir = dir;
    }
}
