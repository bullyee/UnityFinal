using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetecter : MonoBehaviour
{
    public GameObject ballgenerator;
    public GameObject owner;
    [SerializeField] BallGenerator bg;
    [SerializeField] GameObject ball2;
    bool collision_occured = false;
    // Start is called before the first frame update
    void Start()
    {
        bg = ballgenerator.GetComponent<BallGenerator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if ((collision.transform.name.Contains("Plane") || collision.transform.name.Contains("ball")))
        {
            if (!collision_occured)
            {
                bg.GenerateBall(owner.transform);
                collision_occured = true;
            }
            if(!collision.gameObject.activeSelf || !gameObject.activeSelf) return;
            if (collision.transform.name.Contains("ball1"))
            {
                Vector3 pos = collision.transform.position;
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                gameObject.GetComponent<Collider>().enabled = false;
                GameObject c = Instantiate(ball2, (pos + transform.position) / 2, new Quaternion());
                c.transform.parent = bg.transform;
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}