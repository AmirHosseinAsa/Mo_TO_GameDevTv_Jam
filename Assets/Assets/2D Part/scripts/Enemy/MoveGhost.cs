using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGhost : MonoBehaviour
{

    public GameObject ghost;
    public float moveSpeed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Ghost());
    }

    IEnumerator Ghost()
    {
        ghost.transform.position += new Vector3(0, 1f * moveSpeed, 0);
        yield return new WaitForSeconds(5);
        Destroy(ghost);
    }

}
