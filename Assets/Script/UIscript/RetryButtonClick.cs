using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RetryButtonClick : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnPointerClick(PointerEventData e)
    {
        SceneManager.LoadScene(1);
    }

}


