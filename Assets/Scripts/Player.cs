using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    private Rigidbody thisRigidBody = null;
    private float Force = 110;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        thisRigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisRigidBody.AddForce(Vector3.up * Force);
            thisAnimation.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacles")
        {
            GameManager.thisManager.UpdateLives();
        }
    }
}
