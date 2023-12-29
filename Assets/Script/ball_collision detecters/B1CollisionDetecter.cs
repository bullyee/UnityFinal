using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1CollisionDetecter : MonoBehaviour
{
    //Auto Completed when generated
    public GameObject ballgenerator;
    public GameObject owner;
    //使用者設定，下一階的球
    [SerializeField] GameObject ball2;
    //set when Start()
    BallGenerator bg;
    public bool collision_occured = false;
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
        //Check collision with another ball or plane
        if ((collision.transform.name.Contains("Plane") || collision.transform.name.Contains("ball")))
        {
            //generate next ball if first collision
            if (!collision_occured)
            {
                bg.GenerateBall(owner.transform);
                collision_occured = true;
            }
            //prevent one collision code from activating twice
            if(!collision.gameObject.activeSelf || !gameObject.activeSelf) return;
            if (collision.transform.name.Contains("ball1"))
            {
                Vector3 pos = collision.transform.position; //recored position for further use
                //destroy the other game object
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                //instantiate the next lvl ball
                gameObject.GetComponent<Collider>().enabled = false;
                GameObject c = Instantiate(ball2, (pos + transform.position) / 2, new Quaternion());
                c.transform.parent = bg.transform;
                B2CollisionDetecter b = c.GetComponent<B2CollisionDetecter>();
                b.collision_occured = true;
                b.ballgenerator = ballgenerator;
                b.owner = owner;
                //destroy self
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}