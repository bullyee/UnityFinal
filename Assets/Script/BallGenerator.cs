using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] List<GameObject> balls = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateBall(Transform t)
    {
        System.Random rand = new System.Random();
        int b = rand.Next(balls.Count);
        GameObject c = Instantiate(balls[b], t.position, new Quaternion());
        Collider collider = c.GetComponent<Collider>();
        collider.enabled = false;
        c.transform.parent = t;
        if (b == 0)
        {
            B1CollisionDetecter cdt = c.GetComponent<B1CollisionDetecter>();
            cdt.owner = t.gameObject;
            cdt.ballgenerator = transform.gameObject;
        }
        else if (b == 1)
        {
            B2CollisionDetecter cdt = c.GetComponent<B2CollisionDetecter>();
            cdt.owner = t.gameObject;
            cdt.ballgenerator = transform.gameObject;
        }
        else if (b == 2)
        {
            B3CollisionDetecter cdt = c.GetComponent<B3CollisionDetecter>();
            cdt.owner = t.gameObject;
            cdt.ballgenerator = transform.gameObject;
        }
        else
        {
            B4CollisionDetecter cdt = c.GetComponent<B4CollisionDetecter>();
            cdt.owner = t.gameObject;
            cdt.ballgenerator = transform.gameObject;
        }
        Rigidbody rg = c.GetComponent<Rigidbody>();
        rg.useGravity = false;
        rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        t.transform.GetComponent<BallDrop>().current = c;
    }

    public void DropBall(Transform t)
    {
        BallDrop fd = t.GetComponent<BallDrop>();
        if (fd.current == null) return;
        fd.current.transform.parent = transform;
        Collider cld = fd.current.GetComponent<Collider>();
        cld.enabled = true;
        Rigidbody rg = fd.current.GetComponent<Rigidbody>();
        rg.useGravity = true;
        rg.constraints = RigidbodyConstraints.None;
        fd.current = null;
    }
}
