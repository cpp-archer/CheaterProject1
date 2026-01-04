using Unity.VisualScripting;
using UnityEngine;

public class display : MonoBehaviour
{

    public GameObject[] objSpawn;
    //public GameObject pont;
    //public GameObject pierre;
    //public GameObject arbre;

    //public Terrain terrain;
    public GameObject terrain;


    private Transform[] spawnpoints;


    void Start()
    {
        GenTerrain();

    }
    void GenTerrain()
    {
        Renderer cube = terrain.GetComponent<Renderer>();
        Bounds bounds = cube.bounds;

        //Vector3 sizeTerrain = terrain.transform.localScale;
        //Vector3 origin = terrain.transform.position;

        for(int i=0; i < objSpawn.Length; i++)
        {
            float randomX = Random.Range(bounds.min.x, bounds.max.x);
            float randomZ = Random.Range(bounds.min.z, bounds.max.z);
            float randomY = bounds.max.y;

            Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);

            //Instantiate(objSpawn[i], spawnPosition, Quaternion.identity);

            GameObject obj = Instantiate(objSpawn[i]);
            obj.transform.position = spawnPosition;


            //float randomX = Random.Range(origin.x, origin.x + sizeTerrain.x);
            //float randomZ = Random.Range(origin.z, origin.z + sizeTerrain.z);

            //float y = terrain.SampleHeight(new Vector3(randomX, 0, randomZ)) + origin.y;

            //Vector3 spawnPosition = new Vector3(randomX, y, randomZ);
            //Instantiate(objSpawn[i], spawnPosition, Quaternion.identity);

        }

        //Transform randomPoint = spawnpoints[Random.Range(0, spawnpoints.Length)];

        //GameObject instantiated = Instantiate(pont, randomPoint.position, Quaternion.identity);

        //instantiated.transform.position = randomPoint.position;
        ////random position = new vector3(point x random sur la map, point y random, point z random); //instantiate l'objet?
    }
}
