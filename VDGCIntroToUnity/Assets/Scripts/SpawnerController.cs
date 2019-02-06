using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{

    //Spawner Variables
    public GameObject Spawnee;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(Spawnee.GetComponent<Collider>(), GetComponent<Collider>());

        InvokeRepeating("spawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnObject()
    {
        Instantiate(Spawnee,new Vector3(Globals.border,transform.position.y-1f,Random.Range(-Globals.border,Globals.border)),transform.rotation);
    }

}
