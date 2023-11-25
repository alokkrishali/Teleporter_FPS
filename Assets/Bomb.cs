using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject bomb;
    void Start()
    {
        
    }
    bool IsThrown = false;
    public void onThrow()
    {
        IsThrown = true;
        Invoke("bombBlast", 2);
    }

    void bombBlast()
    {
        if(IsThrown)
            Instantiate(bomb, transform.position, Quaternion.identity);
        IsThrown = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
