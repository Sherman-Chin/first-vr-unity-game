using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public List<GameObject> m_FruitsSpawns;

    //Time variable
    public float m_SpawnTime = 1f;
    public float m_SpawnVariance = 0.25f;

    //Spawn variables
    public float m_SpawnForce = 10f;
    public float m_TorqueForce = 5f;
    public Transform m_Spawnpoint;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnAFruit", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void SpawnAFruit()
    {
        int fruitCount = m_FruitsSpawns.Count;

        //Check if our fruit list has at least one fruit available to spawn. A good practice is to ask for users
        //to insert an ojbect if there isn't. 
        if (fruitCount > 0)
        {
            GameObject fruit = m_FruitsSpawns[Random.Range(0, fruitCount)];

            GameObject fruitObject = Instantiate(fruit, m_Spawnpoint.position, m_Spawnpoint.rotation);

            fruitObject.GetComponent<Rigidbody>().AddForce(m_Spawnpoint.up * m_SpawnForce, ForceMode.Impulse);
            fruitObject.GetComponent<Rigidbody>().AddTorque(m_Spawnpoint.right * m_TorqueForce, ForceMode.Impulse);

            Destroy(fruitObject, 5f);
;        }

        //Adds unpredictability to the game mechanics so that it is a bit more interesting (varies).
        float delay = m_SpawnTime + Random.Range(-m_SpawnVariance, m_SpawnVariance);

        Invoke("SpawnAFruit", delay);

    }
}
