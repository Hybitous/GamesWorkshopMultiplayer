using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    [SerializeField] Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        if (materials.Length > 0)
        {
            Material m = materials[Random.Range(0, materials.Length)];
            GetComponent<MeshRenderer>().material = m;
        }
        else
        {
            Debug.Log("Materials missing: "+gameObject.name);
        }
        Destroy(this);
    }
    
}
