using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance;

    public List<Transform> competitorListMain;
    public List<Transform> platformList;

    public float secondsForSpeedChange;

    private float previousTime;
    private Quaternion mechanismRotationInit;

    //TO DO
    //temporal competitor list will be added for controling win lose;

    [SerializeField] private float maxMechSpeed;
    [SerializeField] private GroundMechanism mechanism;
    [SerializeField] private int rotationDir = 1;
    [SerializeField] private float mechanismSpeed = 20;
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
        mechanismRotationInit = mechanism.transform.rotation;
    }

    public void StartGame()
    {
        mechanism.ChangeSpeed(mechanismSpeed);
        mechanism.ChangeRotationDir(rotationDir);

        previousTime = Time.time;
    }

    public void ResetGame()
    {
        mechanismSpeed = 20;
        mechanism.ChangeRotationDir(0);
        mechanism.ChangeSpeed(mechanismSpeed);
        mechanism.transform.rotation = mechanismRotationInit;

        for (int i = 0; i < competitorListMain.Count; i++)
        {
            competitorListMain[i].GetComponent<UnitBaseBehaviour>().Reset(platformList[i]);
        }
    }

    public void ChangeMechanismSpeed()
    {
        mechanismSpeed += mechanismSpeedDelta;
        mechanism.ChangeSpeed(mechanismSpeed);
    }
    public void ChangeMechanismDir()
    {
        rotationDir = -rotationDir;
        mechanism.ChangeRotationDir(rotationDir);
    }

    // Update is called once per frame
    void Update()
    {
        if(mechanismSpeed <= maxMechSpeed && Time.time - previousTime > secondsForSpeedChange)
        {
            var randomDir = Random.Range(0, 1);
            if(randomDir  == 1)
            {
                ChangeMechanismDir();
            }
            ChangeMechanismSpeed();
            previousTime = Time.time;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            mechanismSpeed += mechanismSpeedDelta;
            mechanism.ChangeSpeed(mechanismSpeed);
        }
    }
}
