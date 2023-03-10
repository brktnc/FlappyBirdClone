using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float deleteZone = -20;

    void Start()
    {
       
    }

    void Update()
    {
        transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        if (transform.position.x < deleteZone)
        {
            Debug.Log("Pipe deleted.");
            Destroy(gameObject);
        }
    }
}
