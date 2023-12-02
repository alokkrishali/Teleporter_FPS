using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    Transform thisTransform;

    [SerializeField] float rotationSpeed = 50;
    MeshRenderer thisMeshRend;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        thisMeshRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        thisTransform.RotateAround(thisTransform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            thisMeshRend.enabled = false;
            Debug.Log("got power Up");
            ScoreManager.instance.UpdateScore(1);
        }
    }
}
