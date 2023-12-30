using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B7CollisionDetecter : MonoBehaviour
{
    //�p�����Ʀr���
    public GameObject catchboard;
    scorecounter sc;
    //
    public GameObject ballgenerator;
    public GameObject owner;
    [SerializeField] BallGenerator bg;
    [SerializeField] GameObject ball8;
    // Start is called before the first frame update
    void Start()
    {
        bg = ballgenerator.GetComponent<BallGenerator>();
        catchboard = GameObject.Find("scoreboard");
        sc = catchboard.GetComponent<scorecounter>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.activeSelf || !gameObject.activeSelf) return;
        if (collision.transform.name.Contains("ball7"))
        {
            Vector3 pos = collision.transform.position;
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            gameObject.GetComponent<Collider>().enabled = false;
            GameObject c = Instantiate(ball8, (pos + transform.position) / 2, new Quaternion());
            c.transform.parent = bg.transform;
            B8CollisionDetecter b = c.GetComponent<B8CollisionDetecter>();
            b.ballgenerator = ballgenerator;
            b.owner = owner;
            gameObject.SetActive(false);
            Destroy(gameObject);
            sc.scoreadd(7);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }
}