using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class Inicio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    SpriteRenderer mSpriteRenderer;


    private void Start() 
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mSpriteRenderer.color = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mSpriteRenderer.color = Color.white;
    }
}
