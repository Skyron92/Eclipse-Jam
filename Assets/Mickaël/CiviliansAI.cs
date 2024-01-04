using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CiviliansAI : MonoBehaviour
{
    [SerializeField] private float MaximumWalkingDuration = 1.0f;
    [SerializeField] private float MinimumStandingDuration = 1.0f;
    [SerializeField] private float MaxLifePoints = 100.0f;
    [SerializeField] private float BurningSpeed = 50.0f;
    [SerializeField] private GameObject fearParticles;
    [SerializeField] private GameObject fireParticles;
    [SerializeField] private Transform model;
    [SerializeField] private Animator animator;

    public static List<CiviliansAI> m_AIList = new List<CiviliansAI>();

    private static bool done;
    private static GameObject World;

    [DoNotSerialize] public bool isBurning;
    [DoNotSerialize] public bool hasSunglasses;

    private state actualState;
    private float timer;
    private Vector3 direction;
    private float speed;
    private float WalkingDuration;
    private float StandingDuration;
    private float lifePoint;
    private bool burningValues;
    private float runTimer = 1.0f;

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

    public static void FinishThem()
    {
        foreach (var item in m_AIList)
        {
            if (item.gameObject.activeSelf != true)
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
                    fireParticles.SetActive(true);
                    fearParticles.SetActive(true);
                    actualState = state.Burning;
                    direction = Random.onUnitSphere;
                    speed = Random.Range(-90, 90);
                    if (speed <= 0 && speed > -45) speed = -45;
                    if (speed >= 0 && speed < 45) speed = 45;
                    burningValues = true;
                }
                lifePoint -= BurningSpeed * Time.deltaTime;
                if (lifePoint < 0)
                {
                    actualState = state.Dead;
                }
            }
            switch (actualState)
            {
                case state.Standing:
                    if (timer > StandingDuration)
                    {
                        direction = Random.onUnitSphere;
                        speed = Random.Range(-90, 90);
                        WalkingDuration = Random.Range(0.5f, MaximumWalkingDuration);
                        actualState = state.Walking;
                        timer = 0;
                        CivilsAnimation.AnimationManager(actualState, animator);
                    }
                    break;
                case state.Walking:
                    if (timer > WalkingDuration)
                    {
                        StandingDuration = Random.Range(MinimumStandingDuration, WalkingDuration);
                        actualState = state.Standing;
                        timer = 0;
                        CivilsAnimation.AnimationManager(actualState, animator);
                    }
                    gameObject.transform.RotateAround(World.transform.position, direction, speed * Time.deltaTime);
                    break;
                case state.Burning:
                    if (!isBurning)
                    {
                        fireParticles.SetActive(false);
                        runTimer -= Time.deltaTime;
                        if (runTimer <= 0)
                        {
                            fearParticles.SetActive(false);
                            burningValues = false;
                            actualState = state.Walking;
                            direction = new Vector3(Random.value, Random.value, Random.value);
                            speed = Random.Range(-90, 90);
                            WalkingDuration = Random.Range(0.5f, MaximumWalkingDuration);
                            CivilsAnimation.AnimationManager(actualState, animator);
                        }
                    }
                    else
                    {
                        runTimer = 1.0f;
                    }
                    gameObject.transform.RotateAround(World.transform.position, direction, speed * Time.deltaTime);
                    break;
                case state.Dead:
                    CivilsAnimation.AnimationManager(actualState, animator);
                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) { }
                    {
                        Debug.Log("Je meurs");
                        gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }
}
