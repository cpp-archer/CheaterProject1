using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class display : MonoBehaviour
{

    public GameObject terrain;

    public GameObject[] objSpawn;
    public Transform[] spawnpoints;

    public GameObject grassPrefab;
    public int numberGrass = 100;

    private NavMeshSurface navMeshSurface;

    private Bounds bounds;

    void Awake()
    {
        navMeshSurface = terrain.GetComponent<NavMeshSurface>();

        bounds = terrain.GetComponent<Renderer>().bounds;

        GenObjets();
        GenBalises();
        GenGrass();
        navMeshSurface.BuildNavMesh();
    }



    private void GenObjets()
    {
        //Vector3 sizeTerrain = terrain.transform.localScale;
        //Vector3 origin = terrain.transform.position;

        for (int i = 0; i < objSpawn.Length; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            float randomY = bounds.max.y;

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            GameObject obj = Instantiate(objSpawn[i]);
            obj.transform.position = spawnPosition;
        } 
    }


    private void GenBalises() { 

        for(int i=0; i < spawnpoints.Length; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            float randomY = bounds.max.y;

            spawnpoints[i].position = new Vector3(randomX, randomY, randomZ);
        }
    }


    private void GenGrass(){
        
        for (int i = 0; i < numberGrass; i++)
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float z = Random.Range(bounds.min.z, bounds.max.z);
            float y = bounds.max.y;

            Vector3 pos = new Vector3(x, y, z);

            //instianciation
            GameObject grass = Instantiate(grassPrefab);
            grass.transform.position = pos;
            grass.transform.parent = terrain.transform;

            //rotate et scale random
            grass.transform.Rotate(0, Random.Range(0f, 360f), 0);

            float scale = Random.Range(0.8f, 1.2f);
            grass.transform.localScale *= scale;
        }
    }
}

    

