using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using EzySlice;

public class Katana : MonoBehaviour
{
    public List<AudioClip> chopSounds;
    public ParticleSystem splashParticle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject fruitObject;

        if (collision.gameObject.CompareTag("Slicable"))
        {
            fruitObject = collision.gameObject;

            SlicedHull slicedHull = fruitObject.Slice(transform.position, transform.forward);

            //We want the sliced hull to be created correctly. (Error checking)
            if (slicedHull != null)
            {
                Material fruitMaterial = fruitObject.GetComponent<MeshRenderer>().material;

                GameObject bottomHalf = slicedHull.CreateLowerHull(fruitObject, fruitMaterial);
                GameObject upperHalf = slicedHull.CreateUpperHull(fruitObject, fruitMaterial);

                StartCoroutine(addPhysics(bottomHalf));
                StartCoroutine(addPhysics(upperHalf));

                AudioSource.PlayClipAtPoint(chopSounds[Random.Range(0, chopSounds.Count)], fruitObject.transform.position);

                Instantiate(splashParticle, fruitObject.transform.position, transform.rotation);

                FindObjectOfType<MyGameManager>().addScore(1);

                //Destroys the original object
                Destroy(fruitObject);

                Destroy(bottomHalf, 5f);
                Destroy(upperHalf, 5f);
            }

        }
    }

    IEnumerator addPhysics(GameObject obj)
    {
        //Add mesh collider component
        obj.AddComponent<MeshCollider>().convex = true;

        //Add rigid body component
        obj.AddComponent<Rigidbody>().AddExplosionForce(Random.Range(100f, 300f), obj.transform.position, 10f);


        yield return new WaitForSeconds(0.1f);

        //Add tag
        obj.tag = "Slicable";
    }
}
