using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pause : MonoBehaviour,IPointerClickHandler
{
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerClick(PointerEventData e)
    {
        if (Time.timeScale != 0)
        {
            game.SetActive(true);
            //show_up();
            Time.timeScale = 0;
        }
        else if(Time.timeScale == 0)
        {
            game.SetActive(false);
            //hide_up();
            Time.timeScale = 1;
        }
    }
    public void show_up()
    {
        Transform objTransform = game.transform;
        if (objTransform != null)
        {
            gameObject.SetActive(true);
            objTransform.localScale = Vector3.one * 0.001f;
            objTransform.DOScale(3f, 0.2f);
        }
    }
    public void hide_up()
    {
        Transform objTransform = game.transform;
        if (objTransform != null)
        {
            objTransform.DOScale(0.001f, 0.2f).OnComplete(hide);
        }
    }
    void hide()
    {
        gameObject.SetActive(false);
    }
}
