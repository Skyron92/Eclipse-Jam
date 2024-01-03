using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CiviliansAI : MonoBehaviour
{
    [SerializeField] private float MaximumWalkingDuration = 1.0f;
    [SerializeField] private float MinimumStandingDuration = 1.0f;
    [SerializeField] private float MaxLifePoints = 100.0f;
    [SerializeField] private float BurningSpeed = 50.0f;

    public static List<CiviliansAI> m_AIList = new List<CiviliansAI>();

    private static bool done;
    private static GameObject World;

    [DoNotSerialize] public bool isBurning;
    [DoNotSerialize] public bool hasSunglasses;

    private state actualState;
    private float timer;
    private Vector3 direction;
    private float angle;
    private float WalkingDuration;
    private float StandingDuration;
    private float lifePoint;
    private bool burningValues;

    void Start()
    {
        m_AIList.Add(this);
        if (!done)
        {
            World = GameObject.FindWithTag("Sphere");
            done = true;
        }
        lifePoint = MaxLifePoints;
        StandingDuration = MinimumStandingDuration;
        actualState = state.Standing;
    }
    static public void FinishThem()
    {
        foreach (var item in m_AIList)
        {
            if(item.gameObject.activeSelf != true)
            {
                Destroy(item.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        m_AIList.Remove(this);
    }

    void Update()
    {
        if (!GameManager.Paused)
        {
            timer += Time.deltaTime;
            if (isBurning)
            {
                if (!burningValues)
                {
                    direction = new Vector3(Random.value, Random.value, Random.value);
                    angle = Random.Range(-90, 90);
                    if (angle <= 0 && angle > -45) angle = -45;
                    if (angle >= 0 && angle < 45) angle = 45;
                    burningValues = true;
                }
                actualState = state.Burning;
                lifePoint -= BurningSpeed * Time.deltaTime;
                if (lifePoint < 0)
                {
                    gameObject.SetActive(false);
                }
            }
            switch (actualState)
            {
                case state.Standing:
                    if (timer > StandingDuration)
                    {
                        direction = new Vector3(Random.value, Random.value, Random.value);
                        angle = Random.Range(-90, 90);
                        WalkingDuration = Random.Range(0.5f, MaximumWalkingDuration);
                        actualState = state.Walking;
                        timer = 0;
                    }
                    break;
                case state.Walking:
                    if (timer > WalkingDuration)
                    {
                        StandingDuration = Random.Range(MinimumStandingDuration, WalkingDuration);
                        actualState = state.Standing;
                        timer = 0;
                    }
                    gameObject.transform.RotateAround(World.transform.position, direction, angle * Time.deltaTime);
                    break;
                case state.Burning:
                    if (!isBurning)
                    {
                        burningValues = false;
                        actualState = state.Walking;
                        direction = new Vector3(Random.value, Random.value, Random.value);
                        angle = Random.Range(-90, 90);
                        WalkingDuration = Random.Range(0.5f, MaximumWalkingDuration);
                    }
                    gameObject.transform.RotateAround(World.transform.position, direction, angle * Time.deltaTime);
                    break;
            }
        }
    }
}

enum state
{
    Standing,
    Walking,
    Burning
}
