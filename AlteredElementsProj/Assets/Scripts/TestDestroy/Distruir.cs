using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distruir : MonoBehaviour
{

    [SerializeField] private GameObject objetoA;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Destroy(objetoA);
        }
    }
}
