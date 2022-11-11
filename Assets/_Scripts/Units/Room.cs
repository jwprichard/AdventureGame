using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    new string name;
    [SerializeField] GameObject FOW;

    //void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.T))
    //    {
    //        StartCoroutine(FadeTo(0.0f, 1.0f));
    //    }
    //    if (Input.GetKeyUp(KeyCode.F))
    //    {
    //        StartCoroutine(FadeTo(1.0f, 1.0f));
    //    }
    //}

    public IEnumerator FadeTo(float aValue, float aTime)
    {
        //float alpha = FOW.transform.renderer.material.color.a;
        //float alpha = FOW.GetComponent<SpriteRenderer>().color.a;
        Color color = FOW.GetComponent<SpriteRenderer>().color;
        float alpha = color.a;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            //Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            color.a = Mathf.Lerp(alpha, aValue, t);
            Color newColor = color;
            FOW.GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
}
