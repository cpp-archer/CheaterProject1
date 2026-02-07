using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class display : MonoBehaviour
{
 
    public GameObject terrain;
    public GameObject terrain2;
    public GameObject terrainPatrouille;

    private Bounds bounds;
    private Bounds boundsBalises;
    public GameObject[] objSpawn;
    public Transform[] spawnpoints;

  
    private NavMeshSurface navMeshSurface;
    private NavMeshSurface navMesh2;
    private NavMeshSurface terrainPatrouilleMesh;

    //prefab du pont vers grimoire
    public GameObject ponts;
    public Transform[] pontsPos = { }; //pont dans une des 3 pos possibles
    
    public GameObject grimoire;

    void Awake()
    {    
        //ponts.SetActive(false);
        navMeshSurface = terrain.GetComponent<NavMeshSurface>();
        navMesh2 = terrain2.GetComponent<NavMeshSurface>();
        terrainPatrouilleMesh = terrainPatrouille.GetComponent<NavMeshSurface>();

        bounds = terrain.GetComponent<Renderer>().bounds;
        boundsBalises = terrainPatrouille.GetComponent<Renderer>().bounds;

        //generations des elements sur la map
        GenObjets();
        GenBalises();
        pagePont();
        
        //navmesh bake à l'awake
        navMeshSurface.BuildNavMesh();
        navMesh2.BuildNavMesh();
        terrainPatrouilleMesh.BuildNavMesh();
    }


    //on genere sur la map les objets pour se cacher à des endoits random
    private void GenObjets()
    {
        for (int i = 0; i < objSpawn.Length; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            float randomY = bounds.max.y;

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            GameObject obj = Instantiate(objSpawn[i]);
            obj.transform.position = spawnPosition;
            obj.transform.parent = terrain.transform;
        } 
    }

    //on genere sur la map les balises de patrouille de li'a
    private void GenBalises() { 

        for(int i=0; i < spawnpoints.Length; i++)
        {
            float randomX = Random.Range(boundsBalises.min.x, boundsBalises.max.x);
            float randomZ = Random.Range(boundsBalises.min.z, boundsBalises.max.z);
            float randomY = boundsBalises.max.y;

            spawnpoints[i].position = new Vector3(randomX, randomY, randomZ);
            spawnpoints[i].transform.parent = terrainPatrouille.transform;
        }
    }

    //on genere le pont a une des 3 pos possible et on deplace le grimoire devant le pont
    private void pagePont()
    {
        int rdm = Random.Range(0, pontsPos.Length);
        print(rdm);

        GameObject pontPref = Instantiate(ponts);
        pontPref.transform.parent = pontsPos[rdm];
        pontPref.transform.localPosition = Vector3.zero;

        Vector3 grimPos = new Vector3(pontPref.transform.position.x, pontPref.transform.position.y , pontPref.transform.position.z + 1.5f);

        grimoire.transform.position = grimPos;
        grimoire.transform.rotation = pontPref.transform.rotation;
    }
}



