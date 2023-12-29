using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDrop : MonoBehaviour
{
    [SerializeField] GameObject ballgenerator;
    [SerializeField] GameObject indicator;
    MeshRenderer indicator_mesh;
    BallGenerator bg;
    public GameObject current = null;
    // Start is called before the first frame update
    void Start()
    {
        indicator_mesh = indicator.GetComponent<MeshRenderer>();
        bg = ballgenerator.GetComponent<BallGenerator>();
        bg.GenerateBall(transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bg.DropBall(transform);
            indicator_mesh.enabled = false;
        }
        if (Input.GetMouseButtonDown(1))
        {
            ToggleIndicator();
        }
    }
    
    void ToggleIndicator()
    {
        if (indicator_mesh.enabled) indicator_mesh.enabled = false;
        else indicator_mesh.enabled = true;
    }
}
