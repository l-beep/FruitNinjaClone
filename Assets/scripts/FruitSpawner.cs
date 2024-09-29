using System.Collections;
using UnityEngine;



public class FruitSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public float left;
    public float right;
    internal static object instance;

    [System.Obsolete]
    private void Start()
    {
        StartCoroutine(SpawnRandomObjects());
     
    
}

    [System.Obsolete]
    private IEnumerator SpawnRandomObjects()
    {
        yield return new WaitForSeconds(1);
        while (true)
        { 
            InstantiateRandomObjects();
            yield return new WaitForSeconds(RandomRepeatrate());
        }
    }
    private void InstantiateRandomObjects()
    {
        int objectsToSpawnIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject go = Instantiate(objectsToSpawn[objectsToSpawnIndex], transform.position, objectsToSpawn[objectsToSpawnIndex].transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(RandomVector() * RandomForce(),ForceMode.Impulse);
    }

    private float RandomForce()
    {
        float force = Random.Range(14f, 16f);
        return force;
    }
    private float RandomRepeatrate()
    {
        float repeatrate = Random.Range(0.5f, 3f);
        return repeatrate;
    }

    private Vector2 RandomVector()
    {
        Vector2 moveDirection = new Vector2(Random.Range(left, right), 1).normalized;
        return moveDirection;
    }
  
}
 