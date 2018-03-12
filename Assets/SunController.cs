using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunController : MonoBehaviour {

    [Range(20, 100f)]
    public float maxGravity = 20;
    [Range(0, 20)]
    public float gravityIncrement = 5;
    [Range(4, 30)]
    public float gravityRadius;


    private float gravity;
    private List<Rigidbody> asteroids = new List<Rigidbody>();

    private void Start()
    {
        GetComponent<SphereCollider>().radius = gravityRadius;
        gravity = 0;
        GameUIController.Instance.SetGravitySlider(GravityToSliderValue());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (gravity < maxGravity)
            {
                gravity += gravityIncrement * Time.deltaTime;
                GameUIController.Instance.SetGravitySlider(GravityToSliderValue());
            }
        }
        else
        {
            if (gravity > 0)
            {
                gravity -= gravityIncrement * Time.deltaTime;
                GameUIController.Instance.SetGravitySlider(GravityToSliderValue());
            }
        }
    }

    private void FixedUpdate()
    {
        if(asteroids.Count > 0)
        {
            for (int index = 0; index < asteroids.Count; index++)
            {
                Rigidbody asteroid = asteroids[index];
                Vector3 forceDirection = (asteroid.transform.position - transform.position).normalized * -1;
                asteroid.AddForce(forceDirection * gravity);
            }
        }
    }

    private float GravityToSliderValue()
    {
        return gravity / maxGravity;
    }

    private void OnTriggerEnter(Collider other)
    {
        asteroids.Add(other.GetComponent<Rigidbody>());
    }

    private void OnTriggerExit(Collider other)
    {
        asteroids.Remove(other.GetComponent<Rigidbody>());
        Destroy(other.gameObject, 0.5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, gravityRadius * transform.localScale.x);
    }
}
