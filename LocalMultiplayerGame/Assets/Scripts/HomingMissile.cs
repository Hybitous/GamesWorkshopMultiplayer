using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    Transform nearestPlayer;
    [SerializeField] float scanAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void ScanForPlayers()
    {
        float angle = 0;
        for (int i = 0; i < scanAngle; i++)
        {
            //Scanning
            if (angle > -1)
            {
                angle++;
            }
        }
    }
}
