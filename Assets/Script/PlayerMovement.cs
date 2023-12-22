using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] GameObject reference;
    [SerializeField] Vector2 minpos, maxpos;
    [SerializeField] int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.position = new Vector3(57.5f, 50.4f,-11.7f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = new Vector3(reference.transform.position.x, 0, reference.transform.position.z) 
            - new Vector3(cam.transform.position.x, 0, cam.transform.position.z);
        Vector3 right = Vector3.Cross(new Vector3(0, 1, 0), forward);
        if (Input.GetKey(KeyCode.LeftShift)) speed = 5;
        else speed = 20;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += forward.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= forward.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += right.normalized * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= right.normalized * speed * Time.deltaTime;
        }
        Vector3 newpos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (newpos.x > maxpos.x) newpos.x = maxpos.x;
        if (newpos.z > maxpos.y) newpos.z = maxpos.y;
        if (newpos.x < minpos.x) newpos.x = minpos.x;
        if (newpos.z < minpos.y) newpos.z = minpos.y;
        transform.position = newpos;
    }
}