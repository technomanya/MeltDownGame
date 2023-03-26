using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance;

    [SerializeField] private GroundMechanism mechanism;
    [SerializeField] private int rotationDir = 1;
    [SerializeField] private float mechanismSpeed = 5;
    [SerializeField] private int mechanismSpeedDelta = 10;
    private void Awake()
    {
        gmInstance = this;
    }
    void Start()
    {
        if(!mechanism)
        {
            mechanism = GameObject.FindGameObjectWithTag("Mechanism").GetComponent<GroundMechanism>();
        }

        Invoke(nameof(StartGame), 3);
    }

    public void StartGame()
    {
        mechanism.ChangeSpeed(mechanismSpeed);
        mechanism.ChangeRotationDir(rotationDir);
    }

    public void ChangeMechanismDir()
    {
        rotationDir = -rotationDir;
        mechanism.ChangeRotationDir(rotationDir);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            mechanismSpeed += mechanismSpeedDelta;
            mechanism.ChangeSpeed(mechanismSpeed);
        }

    }
}
