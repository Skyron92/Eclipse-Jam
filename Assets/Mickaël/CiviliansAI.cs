using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CiviliansAI : MonoBehaviour
{
    [SerializeField] private float MaximumWalkingDuration = 1.0f;
    [SerializeField] private float MinimumStandingDuration = 1.0f;

    private static bool done;
    private static GameObject World;

    private state actualState;
    private float timer;
    private Vector3 direction;
    private float angle;
    private float WalkingDuration;
    private float StandingDuration;

    void Start()
    {
        if (!done)
        {
            World = GameObject.FindWithTag("Sphere");
            done = true;
        }
        StandingDuration = MinimumStandingDuration;
        actualState = state.Standing;
    }

    void Update()
    {
        if (!GameManager.Paused)
        {
            timer += Time.deltaTime;
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
                    this.gameObject.transform.RotateAround(World.transform.position, direction, angle * Time.deltaTime);
                    break;
            }
        }
    }
}

enum state
{
    Standing,
    Walking
}
