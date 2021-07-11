using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Valve.VR;


public class Gun : MonoBehaviour
{
    public float m_Force = 80f;
    public Transform m_SpawnPoint;
    public GameObject m_BulletPrefab;

    public SteamVR_Action_Boolean TriggerPress;

    //differentiates the hand side
    public SteamVR_Input_Sources HandSide;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || TriggerPress.GetStateDown(SteamVR_Input_Sources.Any))
        {
            StartCoroutine("SpawnVolley");
        }
    }
    IEnumerator SpawnVolley()
    {
        for (int i = 0; i < 1; i++)
        {
            //Spawn a copy of our bullet
            GameObject newBullet = Instantiate(m_BulletPrefab, m_SpawnPoint.position, m_SpawnPoint.rotation);

            newBullet.GetComponent<Rigidbody>().AddForce(m_SpawnPoint.forward * m_Force, ForceMode.Impulse);

            Destroy(newBullet, 3f);

            yield return new WaitForSeconds(0.1f);
        }
        

    }
}

