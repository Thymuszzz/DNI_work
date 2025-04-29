using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ShowModelButton : MonoBehaviour
{
    private Transform objectToShow;
    private Action<Transform> clickAction;

    public void Initialize(Transform objectToShow, Action<Transform> clickAction)
    {
        this.objectToShow = objectToShow;
        this.clickAction = clickAction;
        GetComponentInChildren<TMP_Text>().text = objectToShow.gameObject.name;
    }
    

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        clickAction(objectToShow);
    }
}
