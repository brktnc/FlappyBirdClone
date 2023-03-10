using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePipe : MonoBehaviour
{
    LogicManagerScript logicScript;

    // Start is called before the first frame update
    void Start()
    {
        logicScript = FindObjectOfType<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
            logicScript.scoreIncrement(1);
    }
}
