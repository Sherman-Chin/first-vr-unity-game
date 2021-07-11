using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject m_SpawnPrefab;
    public float m_ScaleSpeed = 2f;

    private void OnCollisionEnter(Collision collision)
    {
        //Check if bullet collided with an object that is an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Rigidbody>().AddForce(collision.relativeVelocity);

            //Destroy this bullet
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Spawning"))
        {
            //ContactPoint contactPoint = collision.contacts[0];
            //Vector3 spawnLocation = contactPoint.point;
            //Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);

            //GameObject newObject = Instantiate(m_SpawnPrefab, spawnLocation, spawnRotation);
            //Destroy(newObject, 1f);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                StartCoroutine(changeSize(true, collision.gameObject));
            }
            else
            {
                StartCoroutine(changeSize(false, collision.gameObject));
            }

            Destroy(this.gameObject);
        }
    }

    IEnumerator changeSize(bool increase, GameObject obj)
    {
        if (increase)
        {
            for (int i = 0; i < 10; i++)
            {
                obj.transform.localScale *= 1f + m_ScaleSpeed * Time.deltaTime;
                yield return new WaitForSeconds(0.1f);
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                obj.transform.localScale *= 1f - m_ScaleSpeed * Time.deltaTime;
                yield return new WaitForSeconds(0.1f);

            }
        }
    }
}
