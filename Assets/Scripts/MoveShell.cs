using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShell : MonoBehaviour {

    public float speed = 1.0f;
    [SerializeField] private GameObject enemy;
   
    private void LateUpdate()
    {
        Rotate();
        Move();
    }
    
    private void Move()
    {
         Vector3 direction = (enemy.transform.position - transform.position).normalized;
         Quaternion rotation = Quaternion.LookRotation(direction);
         transform.rotation = rotation;

         Vector3 newPosition = transform.position + direction * speed * Time.deltaTime;

         transform.position = newPosition;
}

private void Rotate()
{
Vector3 forwardVector = transform.forward;
Vector3 playerVector = enemy.transform.position - transform.position;

float vectorMagnitudeToPlayer = Mathf.Sqrt(Mathf.Pow(enemy.transform.position.x - transform.position.x, 2) + Mathf.Pow(enemy.transform.position.z - transform.position.z, 2));
float vectorMagnitudeToForward = Mathf.Sqrt(Mathf.Pow(transform.forward.x, 2) + Mathf.Pow(transform.forward.z, 2));

float angle = Mathf.Acos((forwardVector.x * playerVector.x + forwardVector.z * playerVector.z) / (vectorMagnitudeToPlayer * vectorMagnitudeToForward));

var cross = new Vector3(forwardVector.y * playerVector.z - forwardVector.z * playerVector.y,
    forwardVector.x * playerVector.z - forwardVector.z * playerVector.x,
    forwardVector.x * playerVector.y - forwardVector.y * playerVector.x);

int clockwise = 1;
if (cross.y > 0) clockwise = -1;

if (!float.IsNaN(angle)) transform.Rotate(0,angle * Mathf.Rad2Deg * clockwise,0);
}
}
