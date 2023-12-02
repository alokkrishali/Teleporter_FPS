using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    private int HealthValue = 4;
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
            HelthManager.instance.UpdateHealth(-1);
            Debug.LogError("Health reduce");
        }
    }

    public void ReduceHelth()
    {
        HealthValue--;
        if (HealthValue <= 0)
        {
            ScoreManager.instance.UpdatePowerUps(5);
            OnDead();
        }
    }
    private void OnDead()
    {
        Destroy(this.gameObject);
    }
}
