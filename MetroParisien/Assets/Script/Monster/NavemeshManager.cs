using UnityEngine;
using Unity.AI.Navigation;

public class NavemeshManager : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface navSurface;

    [SerializeField]
    private BakeNavemeshEventDispatcherScriptable bakeEventDispatcher;

    private void Awake()
    {
        if(bakeEventDispatcher == null)
        {
            Debug.LogError("Missing reference to bakeEventDispatcher of type BakeNavemeshEventDispatcherScriptable ");
        }
        if(navSurface == null)
        {
            navSurface = GetComponent<NavMeshSurface>();
        }
    }

    public void OnEnable()
    {
        bakeEventDispatcher.dispatchedEvents[0].AddListener(OnObjectMoved);
    }

    public void OnDisable()
    {
        bakeEventDispatcher.dispatchedEvents[0].RemoveListener(OnObjectMoved);
    }

    public void OnObjectMoved()
    {
        navSurface.BuildNavMesh();
    }
}
