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
