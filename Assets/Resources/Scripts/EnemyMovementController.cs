using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    public Vector3 movementDirection;
    public float movementSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
    }
}
