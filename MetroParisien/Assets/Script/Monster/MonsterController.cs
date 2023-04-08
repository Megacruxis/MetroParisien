using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private Transform targetPostion;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private bool isChassing;

    [SerializeField]
    private ChaseEventDispatcherScriptable chaseEventDispatcher;

    void Awake()
    {
        if(targetPostion == null)
        {
            Debug.LogError("Missing reference to targetPosition of type Vector3");
        } 
        if(agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        if(chaseEventDispatcher == null)
        {
            Debug.LogError("Missing reference to chaseEventDispatcher of type ChaseEventDispatcherScriptable");
        }
    }

    private void OnEnable()
    {
        chaseEventDispatcher.dispatchedEvents[ChaseEventDispatcherScriptable.START_CHASE_EVENT_INDEX].AddListener(StartChase); 
        chaseEventDispatcher.dispatchedEvents[ChaseEventDispatcherScriptable.STOP_CHASE_EVENT_INDEX].AddListener(StopChase); 
    }

    private void OnDisable()
    {
        chaseEventDispatcher.dispatchedEvents[ChaseEventDispatcherScriptable.START_CHASE_EVENT_INDEX].RemoveListener(StartChase);
        chaseEventDispatcher.dispatchedEvents[ChaseEventDispatcherScriptable.STOP_CHASE_EVENT_INDEX].RemoveListener(StopChase);
    }

    private void StartChase()
    {
        isChassing = true;
    }

    private void StopChase()
    {
        isChassing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChassing)
        {
            agent.SetDestination(targetPostion.position);
        }
    }
}
