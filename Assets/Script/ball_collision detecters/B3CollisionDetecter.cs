using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3CollisionDetecter : MonoBehaviour
{
    public GameObject ballgenerator;
    public GameObject owner;
    [SerializeField] BallGenerator bg;
    [SerializeField] GameObject ball4;
    public bool collision_occured = false;
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
        if ((collision.transform.name.Contains("Plane") || collision.transform.name.Contains("ball")))
        {
            if (!collision_occured)
            {
                bg.GenerateBall(owner.transform);
                collision_occured = true;
            }
            if (!collision.gameObject.activeSelf || !gameObject.activeSelf) return;
            if (collision.transform.name.Contains("ball3"))
            {
                Vector3 pos = collision.transform.position;
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
                gameObject.GetComponent<Collider>().enabled = false;
                GameObject c = Instantiate(ball4, (pos + transform.position) / 2, new Quaternion());
                c.transform.parent = bg.transform;
                B4CollisionDetecter b = c.GetComponent<B4CollisionDetecter>();
                b.collision_occured = true;
                b.ballgenerator = ballgenerator;
                b.owner = owner;
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }
}
