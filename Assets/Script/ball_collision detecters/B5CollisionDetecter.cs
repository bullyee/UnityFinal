using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class B5CollisionDetecter : MonoBehaviour
{
    //計分版數字更改
    public GameObject catchboard;
    scorecounter sc;
    //
    public GameObject ballgenerator;
    public GameObject owner;
    [SerializeField] BallGenerator bg;
    [SerializeField] GameObject ball6;
    PopSoundEffect SE;
    // Start is called before the first frame update
    void Start()
    {
        bg = ballgenerator.GetComponent<BallGenerator>();
        catchboard = GameObject.Find("scoreboard");
        sc = catchboard.GetComponent<scorecounter>();
        SE = ballgenerator.GetComponent<PopSoundEffect>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.activeSelf || !gameObject.activeSelf) return;
        if (collision.transform.name.Contains("ball5"))
        {
            Vector3 pos = collision.transform.position;
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject); 
            gameObject.GetComponent<Collider>().enabled = false;
            GameObject c = Instantiate(ball6, (pos + transform.position) / 2, ball6.transform.rotation);
            c.transform.parent = bg.transform;
            SE.PlayPop();
            B6CollisionDetecter b = c.GetComponent<B6CollisionDetecter>();
            b.ballgenerator = ballgenerator;
            b.owner = owner;
            gameObject.SetActive(false);
            Destroy(gameObject);
            sc.scoreadd(5);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }
}
