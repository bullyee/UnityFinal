using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Show_book : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject book;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPointerClick(PointerEventData e)
    {
        if (book.activeSelf == false) book.SetActive(true);
        else book.SetActive(false);
    }

}

