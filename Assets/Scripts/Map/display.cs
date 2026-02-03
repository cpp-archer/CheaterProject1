using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class display : MonoBehaviour
{
 
    public GameObject terrain;
    public GameObject terrain2;
    private Bounds bounds;

    public GameObject[] objSpawn;
    public Transform[] spawnpoints;

  
    private NavMeshSurface navMeshSurface;
    private NavMeshSurface navMesh2;

    //prefab du pont vers grimoire
    public GameObject ponts;
    public Transform[] pontsPos = { }; //pont dans une des 3 pos possibles
    
    public GameObject grimoire;

    void Awake()
    {
        //ponts.SetActive(false);
        navMeshSurface = terrain.GetComponent<NavMeshSurface>();
        navMesh2 = terrain2.GetComponent<NavMeshSurface>();

        bounds = terrain.GetComponent<Renderer>().bounds;

        //generations des elements sur la map
        GenObjets();
        GenBalises();
        pagePont();
        // GenGrass();

        navMeshSurface.BuildNavMesh();
        navMesh2.BuildNavMesh();
    }


    //on genere sur la map les objets pour se cacher à des endoits random
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
            obj.transform.parent = terrain.transform;
        } 
    }


    //on genere sur la map les balises de patrouille de li'a
    private void GenBalises() { 

        for(int i=0; i < spawnpoints.Length; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            float randomY = bounds.max.y;

            spawnpoints[i].position = new Vector3(randomX, randomY, randomZ);
            spawnpoints[i].transform.parent = terrain.transform;
        }
    }


    //private void pagePont()
    //{
    //    for(int i =0; i<ponts.Length; i++)
    //    {
    //        ponts[i].SetActive(true);
    //    }

    //}

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
        //Instantiate(grimoire, grimPos, pontPref.transform.rotation);

        // pontPref.transform.parent = transform;
    }
}



