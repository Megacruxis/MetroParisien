using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
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

    [SerializeField]
    private LevelLoader levelLoader;

    [SerializeField]
    public AnimationCurve m_Curve = new AnimationCurve();

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

    IEnumerator Start()
    {
        agent.autoTraverseOffMeshLink = false;
        while (true)
        {
            if (agent.isOnOffMeshLink)
            {
                yield return StartCoroutine(Curve(agent, 0.75f));
                agent.CompleteOffMeshLink();
            }
            yield return null;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            levelLoader.reloadScene();
        }
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

    IEnumerator Curve(NavMeshAgent agent, float duration)
    {
        OffMeshLinkData data = agent.currentOffMeshLinkData;
        Vector3 startPos = agent.transform.position;
        Vector3 endPos = data.endPos + Vector3.up * agent.baseOffset;
        float normalizedTime = 0.0f;
        while (normalizedTime < 1.0f)
        {
            float yOffset = m_Curve.Evaluate(normalizedTime);
            agent.transform.position = Vector3.Lerp(startPos, endPos, normalizedTime) + yOffset * Vector3.up;
            normalizedTime += Time.deltaTime / duration;
            yield return null;
        }
    }
}
