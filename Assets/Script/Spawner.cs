using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{

    public GameObject[] fruitToSpawn;
    public float minTime = 0.3f, maxTime = 1.0f;
    public Transform[] SpawnPlace;
   
    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    

    private IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            Transform t = SpawnPlace[Random.Range(0, SpawnPlace.Length)];
            GameObject fruit = Instantiate(fruitToSpawn[Random.Range(0,fruitToSpawn.Length)], t.position,t.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up*20,ForceMode2D.Impulse);
            Destroy(fruit,5);

        }

    }
}
