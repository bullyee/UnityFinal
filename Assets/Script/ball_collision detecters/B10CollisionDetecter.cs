using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B10CollisionDetecter : MonoBehaviour
{
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (!collision.gameObject.activeSelf || !gameObject.activeSelf) return;
        if (collision.transform.name.Contains("ball_10"))
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }
}
