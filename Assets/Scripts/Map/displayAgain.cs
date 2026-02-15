using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class displayAgaib : MonoBehaviour
{

    float minDistance = 2.5f;

    public GameObject terrain;
    public GameObject terrainPatrouille;

    private Bounds bounds;
    private Bounds boundsBalises;

    //public GameObject[] objSpawn;
    public Transform[] objPointsSpawn;

    //cachettes et obstacles
    public GameObject[] hides;
    public GameObject[] obstacles;

    //pour l'ia et sa patrouille
    public Transform[] BalisesSpawnpoints;
    public GameObject balises;//DANS LA HIERARCHIE

    //navmesh
    private NavMeshSurface navMeshSurface;
    private NavMeshSurface navMesh2;
    //private NavMeshSurface terrainPatrouilleMesh;

    //prefab du pont vers grimoire
    public GameObject ponts;
    public Transform[] pontsPos = { }; //pont dans une des 3 pos possibles
    public GameObject grimoire;

    //bandes
    public Transform[] bande1;
    public Transform[] bande2;
    public Transform[] bande3;

    //patterns
    GameObject[] pattern1;
    GameObject[] pattern2;
    GameObject[] pattern3;
    GameObject[] pattern4;

    void Awake()
    {
        navMeshSurface = terrain.GetComponent<NavMeshSurface>();
        //terrainPatrouilleMesh = terrainPatrouille.GetComponent<NavMeshSurface>();

        bounds = terrain.GetComponent<Renderer>().bounds;
        boundsBalises = terrainPatrouille.GetComponent<Renderer>().bounds;

        //generations des elements sur la map
        GenObjets();
        GenBalises();
        pagePont();

        //navmesh bake à l'awake
        navMeshSurface.BuildNavMesh();
        //terrainPatrouilleMesh.BuildNavMesh();

    }


    //on genere sur la map les objets pour se cacher à des endoits random
    private void GenObjets()
    {

        //1 pbstacle 2 cachettes 0 vide chemin
        int[] pattern1 = { 1, 0, 2, 0, 2, 1 };
        int[] pattern2 = { 2, 0, 1, 1, 0, 2 };
        int[] pattern3 = { 0, 2, 1, 0, 1, 0 };
        // int[] pattern4 = { 0, 2, 0, 1, 2, 0 };
        int[][] allPattern = { pattern1, pattern2, pattern3 }; //pattern4 };

        int rdm1 = Random.Range(0, 3);
        int rdm2 = Random.Range(0, 3);
        int rdm3 = Random.Range(0, 3);


        GenBandes(bande1, allPattern[rdm1]);
        GenBandes(bande2, allPattern[rdm2]);
        GenBandes(bande3, allPattern[rdm3]);

  
    }


    private void GenBandes(Transform[] bande, int[] pattern)
    {
        //bool lastObject = false;
        for (int i = 0; i < bande.Length; i++)
        {
            GameObject prefab = null;

    
            //if(!lastObject){ 
                
                if (pattern[i] == 1){
                    int rdm = Random.Range(0, obstacles.Length);
                    prefab = obstacles[rdm];
                }

                if (pattern[i] == 2){
                    int rdm = Random.Range(0, hides.Length);
                    prefab = hides[rdm];
                }
           // }

            if (prefab != null) { 
                GameObject obj = Instantiate(prefab);// (objSpawn[i]);
                obj.transform.position = bande[i].position;
                obj.transform.parent = terrain.transform;
                //lastObject = true;

             }
            //else
            //    lastObject = false;
        }
    }
        //on genere sur la map les balises de patrouille de li'a
    private void GenBalises()
    {

        for (int i = 0; i < BalisesSpawnpoints.Length-1; i++)
        {
            float randomX = Random.Range(boundsBalises.min.x, boundsBalises.max.x);
            float randomZ = Random.Range(boundsBalises.min.z, boundsBalises.max.z);
            float randomY = boundsBalises.max.y;

            BalisesSpawnpoints[i].position = new Vector3(randomX, randomY, randomZ);
            BalisesSpawnpoints[i].transform.parent = balises.transform;
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

        Vector3 grimPos = new Vector3(pontPref.transform.position.x, pontPref.transform.position.y, pontPref.transform.position.z + 1.5f);

        grimoire.transform.position = grimPos;
        grimoire.transform.rotation = pontPref.transform.rotation;
        navMeshSurface.BuildNavMesh();

    }
}



