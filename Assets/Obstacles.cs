using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    private int HelthValue = 4;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            HelthManager.instance.UpdateHelth(1);
            Debug.LogError("Helth reduce");
        }
    }

    public void ReduceHelth()
    {
        HelthValue--;
        if (HelthValue <= 0)
            OnDead();
    }
    private void OnDead()
    {
        Destroy(this.gameObject);
    }
}
