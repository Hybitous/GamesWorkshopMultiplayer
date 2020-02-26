using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangRotation : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 500;

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }
}
