using System.Collections;
using System.Collections.Generic;
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
        GameObject c = Instantiate(balls[0], t.position, new Quaternion());
        c.transform.parent = t;
        CollisionDetecter cdt = c.GetComponent<CollisionDetecter>();
        cdt.owner = t.gameObject;
        cdt.ballgenerator = transform.gameObject;
        Rigidbody rg = c.GetComponent<Rigidbody>();
        rg.useGravity = false;
        rg.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        t.transform.GetComponent<FruitDrop>().current = c;
    }

    public void DropBall(Transform t)
    {
        FruitDrop fd = t.GetComponent<FruitDrop>();
        if (fd.current == null) return;
        fd.current.transform.parent = transform;
        Rigidbody rg = fd.current.GetComponent<Rigidbody>();
        rg.useGravity = true;
        rg.constraints = RigidbodyConstraints.None;
        fd.current = null;
    }
}
