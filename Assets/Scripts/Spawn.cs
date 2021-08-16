using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject fishPrefab;
    public GameObject sharkPrefab;
    public float respawnTime = 1.0f;

    // range that fishes spawn
    public float topRange = 1.5f;
    public float bottomRange = -6f;

    void Start() {
        StartCoroutine(spawnFish());
        StartCoroutine(spawnShark());
    }
    
    // creates new fish instance and places it at the position of spawner
    private void createFish() {
        var spawnerPosition = gameObject.transform.position;
        GameObject fish = Instantiate(fishPrefab) as GameObject;

        // places fish at random y value
        fish.transform.position = new Vector3(spawnerPosition.x, Random.Range(topRange, bottomRange), spawnerPosition.z);
    }

    // creates new shark instance and places it at the position of spawner
    private void createShark() {
        var spawnerPosition = gameObject.transform.position;
        GameObject fish = Instantiate(sharkPrefab) as GameObject;

        // places shark at random y value
        fish.transform.position = new Vector3(spawnerPosition.x, Random.Range(topRange, bottomRange), spawnerPosition.z);
    }
    
    IEnumerator spawnFish() {
        // continuously creates new fishes every respawnTime
        while(true) {
            yield return new WaitForSeconds(respawnTime);
            createFish();
        }
    }
    IEnumerator spawnShark() {
        // continuously creates new sharks every 5-10 sec
        while(true) {
            yield return new WaitForSeconds(Random.Range(10f, 20f));
            createShark();
        }
    }
}
