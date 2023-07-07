using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject sliceFruit;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            CreateSlicedFruit();
        }
    }
    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(sliceFruit, transform.position, transform.rotation);
        Rigidbody[] body = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody r in body)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(100,200), r.transform.position, 5f);
        }

        FindObjectOfType<GameManager>().IncreaseScore();
        Destroy(this.gameObject);
        Destroy(inst.gameObject,3);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Blade b = other.GetComponent<Blade>();

        if (!b) 
            return;
        else
            CreateSlicedFruit();
    }
}
