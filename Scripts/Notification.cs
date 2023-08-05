using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public static int text_num = 0;
    public static GameObject text = null;
    GameObject[] texts;
    public GameObject helmet;

    private void Start()
    {
        texts = Get_children(gameObject);

        foreach (GameObject go in texts) { Debug.Log(go); }

        Change_text();
    }

    private void Update()
    {
        text.SetActive(false);
        Change_text();
        text.SetActive(true);
    }

    private GameObject[] Get_children( GameObject obj)
    {
        int children_num = obj.transform.childCount;  
        GameObject[] children = new GameObject[children_num]; 

        for( int ind = 0; ind < children_num; ind++ )
        {
            children[ind] = obj.transform.GetChild(ind).transform.gameObject; 
        }

        return children;
    }
    private void Change_text()
    {
        text_num = Mathf.Clamp(text_num, 0, texts.Length-1);
        text = texts[text_num]; 
        if ( text_num == texts.Length-1 ) { helmet.SetActive(true); }
    }
}
