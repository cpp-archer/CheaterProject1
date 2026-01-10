using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class display : MonoBehaviour
{
    public GameObject[] objSpawn;
    public GameObject terrain;
    public Transform[] spawnpoints;
    private NavMeshSurface navMeshSurface;

    void Start()
    {
   

        navMeshSurface = terrain.GetComponent<NavMeshSurface>();
        GenTerrain();
        navMeshSurface.BuildNavMesh();
    }

    void GenTerrain()
    {
        Renderer cube = terrain.GetComponent<Renderer>();
        Bounds bounds = cube.bounds;

        //Vector3 sizeTerrain = terrain.transform.localScale;
        //Vector3 origin = terrain.transform.position;

        for (int i = 0; i < objSpawn.Length; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            float randomY = bounds.max.y;

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            //Instantiate(objSpawn[i], spawnPosition, Quaternion.identity);

            GameObject obj = Instantiate(objSpawn[i]);
            obj.transform.position = spawnPosition;
        }

        for(int i=0; i < spawnpoints.Length; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            float randomY = bounds.max.y;

            spawnpoints[i].position = new Vector3(randomX, randomY, randomZ);
        }
        //navMeshSurface.BuildNavMesh();
    }
}
