using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class display : MonoBehaviour
{

    public GameObject terrain;

    public GameObject[] objSpawn;
    public Transform[] spawnpoints;

    private NavMeshSurface navMeshSurface;

    private Bounds bounds;

    public GameObject ponts; //prefabs de pont

    public Transform[] pontsPos = { };

    void Awake()
    {

        //ponts.SetActive(false);
        navMeshSurface = terrain.GetComponent<NavMeshSurface>();

        bounds = terrain.GetComponent<Renderer>().bounds;

        GenObjets();
        GenBalises();
        // GenGrass();
        pagePont();
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


    //private void pagePont()
    //{
    //    for(int i =0; i<ponts.Length; i++)
    //    {
    //        ponts[i].SetActive(true);
    //    }

    //}


    private void pagePont()
    {
        int rdm = Random.Range(0, pontsPos.Length);
        print(rdm);

        GameObject pontPref = Instantiate(ponts);
        pontPref.transform.parent = pontsPos[rdm];
        pontPref.transform.localPosition = Vector3.zero;

       // pontPref.transform.parent = transform;
    }
}



