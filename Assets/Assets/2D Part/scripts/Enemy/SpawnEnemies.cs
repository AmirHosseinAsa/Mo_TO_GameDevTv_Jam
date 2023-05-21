using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public int enemyCount = 5;
    public GameObject enemy;
    public int enemyTimeout = 30;

    private float x_position;
    private GameObject[] enemyArray;
    private GameObject enemyInstance;

    // Start is called before the first frame update
    void Start()
    {
        enemyArray = new GameObject[enemyCount];
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Spawn()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            x_position = Random.Range(-60, 60);
            enemyInstance = Instantiate(enemy, new Vector3(x_position, 0, 0), Quaternion.identity);
            enemyArray[i] = enemyInstance;
            yield return new WaitForSeconds(1f);
            enemyCount -= 1;
        }

        yield return new WaitForSeconds(enemyTimeout);
        DestroyEnemies();
    }

    public void DestroyEnemies()
    {
        foreach (GameObject spawnedObject in enemyArray)
        {
            Destroy(spawnedObject);
        }
    }

}
