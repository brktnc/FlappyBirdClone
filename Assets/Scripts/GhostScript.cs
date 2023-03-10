using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] GameObject cameraTrigger;
    [SerializeField] float flyStrength;

    public bool ghostIsAlive = true;

    [SerializeField] AudioSource uhSFX;
    [SerializeField] AudioSource fellDownSFX;

    LogicManagerScript logicScript;

    void Start()
    {
        logicScript = FindObjectOfType<LogicManagerScript>();
        cameraTrigger = GameObject.FindWithTag("maincameratrigger");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ghostIsAlive)
        {
            rigidbody.velocity = Vector2.up * flyStrength;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ghostIsAlive = false;
        uhSFX.Play();
        logicScript.gameOver();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "maincameratrigger" || collision.tag == "upcameratrigger" || collision.tag == "downcameratrigger" && ghostIsAlive)
        {
            if (collision.tag == "upcameratrigger")
            {
                rigidbody.gravityScale = 0;
            }
            else if (collision.tag == "downcameratrigger")
            {
                rigidbody.gravityScale = 1000;
            }
            fellDownSFX.Play();
            logicScript.gameOver();
        }
    }
}
