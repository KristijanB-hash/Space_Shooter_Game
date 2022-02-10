using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarierSpawner : MonoBehaviour
{
    public GameObject Prefab;
    // public int numberOfBottles;
    public float delayOfSpawning;
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(BarierWave());
    }

    private void SpawnBarier()
    {
        GameObject spawner = Instantiate(Prefab) as GameObject;
        spawner.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x),screenBounds.y * 2);
    }

    IEnumerator BarierWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(delayOfSpawning);
            SpawnBarier();
        }
    }
}
