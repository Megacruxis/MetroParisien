using UnityEngine;
using Unity.AI.Navigation;

public class NavemeshManager : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface navSurface;

    private void Awake()
    {
        if(navSurface == null)
        {
            navSurface = GetComponent<NavMeshSurface>();
        }
    }

    public void OnObjectMoved()
    {
        navSurface.BuildNavMesh();
    }
}
