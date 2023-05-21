using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;
    public float yOffset = 1f;
    public float zOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, target.position.y + yOffset, zOffset);
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
