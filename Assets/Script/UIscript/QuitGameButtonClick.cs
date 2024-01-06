using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuitGameButtonClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject book;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnPointerClick(PointerEventData e)
    {
        Application.Quit();
    }

}


