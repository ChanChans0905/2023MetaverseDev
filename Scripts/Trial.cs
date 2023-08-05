using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour
{
    public GameObject scooter;
    int text_num = 0;
    GameObject text = null;
    GameObject[] texts;

    private void Start()
    {
        texts = Get_children(gameObject);
        Change_text();
    }

    private void Update()
    {
        text.SetActive(false);
        if(OVRInput.GetDown (OVRInput.RawButton.A))
        {
            text_num++; 
        }
        Change_text();
        text.SetActive(true);
    }

    private GameObject[] Get_children(GameObject obj)
    {
        int children_num = obj.transform.childCount;
        GameObject[] children = new GameObject[children_num];

        for (int ind = 0; ind < children_num; ind++)
        {
            children[ind] = obj.transform.GetChild(ind).transform.gameObject;
        }

        return children;
    }
    private void Change_text()
    {
        text_num = Mathf.Clamp(text_num, 0, texts.Length - 1);
        text = texts[text_num];
        if (text_num == texts.Length -1) 
        { 
            Destroy(gameObject.transform.parent.gameObject);
            scooter.SetActive(true); 
        }
    }

}
