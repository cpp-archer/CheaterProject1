using UnityEngine;

public class grass : MonoBehaviour
{
    public GameObject grassPrefab;
    public int grassCount = 50;
    public GameObject terrain;
    void Start()
    {

        Renderer cube = terrain.GetComponent<Renderer>();
        Bounds bounds = cube.bounds;

        for (int i = 0; i < grassCount; i++)
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float z = Random.Range(bounds.min.z, bounds.max.z);
            float y = bounds.max.y; // dessus du cube

            Vector3 pos = new Vector3(x, y, z);

            //GameObject grass = Instantiate(grassPrefab, pos, Quaternion.identity);

            GameObject grass = Instantiate(grassPrefab); //, pos, Quaternion.identity);
            grass.transform.position = pos;
            grass.transform.parent = terrain.transform;

            // rotation aléatoire
            grass.transform.Rotate(0, Random.Range(0f, 360f), 0);

            // scale aléatoire
            float scale = Random.Range(0.8f, 1.2f);
            grass.transform.localScale *= scale;
        }
    }
}
