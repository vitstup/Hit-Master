using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterController : MonoBehaviour, IResatable
{
    public static UnityEvent WayPointReached = new UnityEvent();

    private NavMeshAgent agent;
    private AnimationController animationController;

    private bool isRunning;

    private Vector3 startPos;
    private Quaternion startRot;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    private void Update()
    {
        if (isRunning && Vector3.Distance(agent.transform.position, agent.destination) < 0.1f)
        {
            Debug.Log("Reached pos");
            isRunning = false;
            animationController.SetIsRunning(false);

            WayPointReached?.Invoke();
        }
    }

    public void MoveTo(Vector3 pos)
    {
        agent.SetDestination(pos);
        animationController.SetIsRunning(true);
        isRunning = true;
    }

    public void ResetAll()
    {
        agent.enabled = false;
        transform.position = startPos;
        transform.rotation = startRot;
        agent.enabled = true;
        agent.SetDestination(startPos);

        Debug.Log("Chara reseted");
    }
}