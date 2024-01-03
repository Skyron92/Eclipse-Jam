using UnityEngine;

public class CiviliansAI : MonoBehaviour
{
    [SerializeField] private float WalkingDuration = 1.0f;
    [SerializeField] private float StandingDuration = 1.0f;


    private static GameObject World;

    private state actualState;
    private float timer;
    private Vector3 direction;
    private float angle;

    void Start()
    {
        World = GameObject.FindWithTag("Sphere");
        actualState = state.Standing;
    }

    void Update()
    {
        timer += Time.deltaTime;
        switch (actualState)
        {
            case state.Standing:
                if (timer > StandingDuration)
                {
                    direction = new Vector3(Random.value, Random.value, Random.value);
                    angle = Random.Range(-180, 180);
                    actualState = state.Walking;
                    timer = 0;
                }
                break;
            case state.Walking:
                
                if (timer > WalkingDuration)
                {
                    actualState = state.Standing;
                    timer = 0;
                }
                this.gameObject.transform.RotateAround(World.transform.position, direction, angle * Time.deltaTime);
                break;
        }
    }
}

enum state
{
    Standing,
    Walking
}
