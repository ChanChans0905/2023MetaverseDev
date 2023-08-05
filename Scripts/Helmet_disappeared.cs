using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet_disappeared : MonoBehaviour
{
    public GameObject notification;
    public GameObject trial; 
    Color transparent_color = new Color(1, 0, 0, 0.02f);
    Color non_transparent_color = new Color(1, 0, 0, 0); 

    public void Is_Hovered()
    {
        this.GetComponent<MeshRenderer>().material.color = transparent_color ; 
    }

    public void Is_UnHovered()
    {
        this.GetComponent<MeshRenderer>().material.color = non_transparent_color;
    }

    public void Is_Selected()
    {
        Destroy(this.transform.parent.gameObject);
        Destroy(notification);
        trial.SetActive(true);

    }

}
