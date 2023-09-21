using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnlargeOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool mouseOver;
    float timer;

    [SerializeField] private AnimationCurve startCurve;
    [SerializeField] private AnimationCurve endCurve;
    [SerializeField] private float speed;

    

    private void Update()
    {
        timer += Time.deltaTime * speed;
        timer = Mathf.Clamp01(timer);
        if(mouseOver)
        {
            float scale = startCurve.Evaluate(timer);
            transform.localScale = new Vector3(scale, scale, scale);
        }
        else
        {
            float scale = endCurve.Evaluate(timer);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    void SetState(bool stateChange)
    {
        mouseOver = stateChange;
        timer = 0f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetState(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetState(false);
    }
}
