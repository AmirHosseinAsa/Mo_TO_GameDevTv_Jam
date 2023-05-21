using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWitch : MonoBehaviour
{

    public GameObject witch;
    public float witchSpeed = 1;
    public int timeOnScreen = 20;
    public int spawnTimes = 2;
    public float spawnHeight = 4;
    private float x_position;
    public static GameObject witchInstance;
    private bool setEnd = false;
    public static int hitCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(witchInstance != null)
        {
            if (x_position >= 0)
            {
                witchInstance.transform.position += new Vector3(witchSpeed * -0.01f, Random.Range(-0.1f, 0.1f), 0);
                
            }
            else
            {
                witchInstance.transform.position += new Vector3(witchSpeed * 0.01f, Random.Range(-0.1f, 0.1f), 0);
                witchInstance.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        if(hitCounter == 5)
        {
            PlayerController.points += 20;
            Destroy(witchInstance);
            hitCounter = 0;
        }
        
    }


    IEnumerator Spawn()
    {
        while(spawnTimes != 0)
        {
            yield return new WaitForSeconds(Random.Range(20, 60));
            x_position = Random.Range(-60, 60);
            Debug.Log("SPAWNED X=" + x_position);
            witchInstance = Instantiate(witch, new Vector3(x_position, spawnHeight, 0), Quaternion.identity);
            yield return new WaitForSeconds(timeOnScreen);
            Destroy(witchInstance);
            spawnTimes--;
        }
       
    }

}
