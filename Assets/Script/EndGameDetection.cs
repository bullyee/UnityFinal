using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]

public class EndGameDetection : MonoBehaviour
{
    public GameObject EndgameUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "End" && enabled)
        {
            Physics.simulationMode = SimulationMode.Script;
            //add scene transform here
            EndgameUI.SetActive(true);
            scorecounter sc = GameObject.Find("scoreboard").GetComponent<scorecounter>();
            sc.score_03 = GameObject.Find("record1").GetComponent<Image>();
            sc.score_02 = GameObject.Find("record2").GetComponent<Image>();
            sc.score_01 = GameObject.Find("record3").GetComponent<Image>();
            sc.score_00 = GameObject.Find("record4").GetComponent<Image>();
            sc.scoreadd(0);
            
        }
    }
}
