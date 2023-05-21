using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnBoss1 : MonoBehaviour
{
    public GameObject boss;
    public float speed = 10;
    public int timeOnScreen = 60;
    private float x_position;
    private GameObject bossInstance;
    public static int hitCounter = 0;
    public int spawnAfterTime = 60;
    public static bool isDead = false;
    public float hitsToKill = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (hitCounter == hitsToKill)
        {
            PlayerController.points += 100;
            //Destroy(bossInstance);
            hitCounter = 0;
            isDead = true;

            //TODO: make it harder
            Debug.Log("Level Complited: Make it harder");
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(spawnAfterTime);
        x_position = Random.Range(-40, 40);
        Debug.Log("SPAWNED X=" + x_position);
        bossInstance = Instantiate(boss, new Vector3(x_position, 0.01f, 0), Quaternion.identity);
        yield return new WaitForSeconds(timeOnScreen);
        Destroy(bossInstance);

        //TODO: Swich to 3d
        Debug.Log("Game Over: Swich to 3D");
        SceneManager.LoadScene(0);
    }
}
