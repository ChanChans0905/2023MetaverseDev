using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Click : MonoBehaviour
{
    private Button button;

    public void Clicked()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.Invoke();
    }
    public void Move2Next_P()
    {
        Notification.text_num += 1; 
    }

    public void Move2Back_P()
    {
        Notification.text_num -= 1;
    }
}
