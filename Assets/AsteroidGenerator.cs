using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour {

    public List<Rigidbody> asteroidsPrefabs;
    [Range(0.1f,4)]
    public float spawnFrecuency = 1;
    [Range(1, 50)]
    public float massMaxRange;
    public List<Transform> spawnPoints;

    private void Start()
    {
        StartCoroutine(Spawn(spawnFrecuency));
    }

    private IEnumerator Spawn(float spawnFrecuency)
    {
        while (true)
        {
            int spIndex = Random.Range(0, spawnPoints.Count);
            int astIndex = Random.Range(0, asteroidsPrefabs.Count);
            Rigidbody asteroid = Instantiate(asteroidsPrefabs[astIndex], spawnPoints[spIndex].position, Quaternion.identity);
            asteroid.mass = Random.Range(1, massMaxRange);
            yield return new WaitForSeconds(spawnFrecuency);
        }
    }
}
