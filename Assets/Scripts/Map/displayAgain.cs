using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class displayAgain : MonoBehaviour
{

    //float minDistance = 2.5f;

    public GameObject terrain;
    public GameObject terrainPatrouille;

    //private Bounds bounds;
    //private Bounds boundsBalises;

    //public GameObject[] objSpawn;
    //public Transform[] objPointsSpawn;

    //cachettes et obstacles
    public GameObject[] hides;
    public GameObject[] obstacles;


    //navmesh
    private NavMeshSurface navMeshSurface;


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

    //rocher grimoire
    public GameObject terrainGrim;
    private NavMeshSurface terrainGrimMesh;

    void Awake()
    {
        //recup navmeshsurface
        navMeshSurface = terrain.GetComponent<NavMeshSurface>();
        terrainGrimMesh = terrainGrim.GetComponent<NavMeshSurface>();

        //bounds = terrain.GetComponent<Renderer>().bounds;
        //boundsBalises = terrainPatrouille.GetComponent<Renderer>().bounds;

        //generations des elements sur la map
        GenObjets();
        pagePont();

        //navmesh bake à l'awake
        navMeshSurface.BuildNavMesh();
        terrainGrimMesh.BuildNavMesh();

    }

    //on genere les patterns des objets
    private void GenObjets()
    {
        //1 pbstacle 2 cachettes 0 vide 
        int[] pattern1 = { 1, 0, 2, 0, 2, 1 };
        int[] pattern2 = { 2, 0, 1, 1, 0, 2 };
        int[] pattern3 = { 0, 2, 1, 0, 1, 0 };
        int[][] allPattern = { pattern1, pattern2, pattern3 }; 

        //ne pas repeter 2 bandes
        int[] ordre = { 0, 1, 2 };//on randomise l'ordre de ce tab

        for(int i = 0; i< ordre.Length; i++)//i = rdm 1,2,3
        {
            int rdm = Random.Range(0, ordre.Length);
            int save = ordre[i];
            ordre[i] = ordre[rdm];
            ordre[rdm] = save;//swap index et nb
        }

        GenBandes(bande1, allPattern[ordre[0]]);
        GenBandes(bande2, allPattern[ordre[1]]);
        GenBandes(bande3, allPattern[ordre[2]]);


        //pattern peut se repeter
        //int rdm1 = Random.Range(0, 3);
        //int rdm2 = Random.Range(0, 3);
        //int rdm3 = Random.Range(0, 3);
        //GenBandes(bande1, allPattern[rdm1]);
        //GenBandes(bande2, allPattern[rdm2]);
        //GenBandes(bande3, allPattern[rdm3]);
    }


    //on place les objets sur chaque bande selon le pattern
    private void GenBandes(Transform[] bande, int[] pattern)
    {
        //pour pas remettre 2 fois le meme objet, vu que yen a beaucoup autant que ce soit diverse
        //List<GameObject> okObstacle = new List<GameObject>(obstacles);
        //List<GameObject> okHides = new List<GameObject>(hides);


        //bool lastObject = false;
        for (int i = 0; i < bande.Length; i++)
        {
            GameObject prefab = null;
    
            //if(!lastObject){ 
                
                if (pattern[i] == 1) { //} && okObstacle.Count > 0){
                    int rdm = Random.Range(0, obstacles.Length);
                    prefab = obstacles[rdm];
                    //okObstacle.RemoveAt(rdm);
            }

                if (pattern[i] == 2) { //} && okHides.Count > 0){
                    int rdm = Random.Range(0, hides.Length);
                    prefab = hides[rdm];
                   // okHides.RemoveAt(rdm);

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


    //on genere le pont a une des 3 pos possible et on deplace le grimoire devant le pont
    private void pagePont()
    {
        int rdm = Random.Range(0, pontsPos.Length);
        //print(rdm);

        GameObject pontPref = Instantiate(ponts);
        pontPref.transform.parent = pontsPos[rdm];
        pontPref.transform.localPosition = Vector3.zero;

        Vector3 grimPos = new Vector3(pontPref.transform.position.x, pontPref.transform.position.y, pontPref.transform.position.z + 1.5f);

        grimoire.transform.position = grimPos;
        grimoire.transform.rotation = pontPref.transform.rotation;
        navMeshSurface.BuildNavMesh();
    }
}



