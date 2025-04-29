using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public int maxSelections = 3;
    public GameObject confirmButton; // 赋值为“火焰料理”按钮
    private List<SelectableButton> selectedButtons = new List<SelectableButton>();

    private void Start()
    {
        confirmButton.SetActive(false); // 默认隐藏
    }

    public bool CanSelect()
    {
        return selectedButtons.Count < maxSelections;
    }

    public void AddSelection(SelectableButton button)
    {
        if (!selectedButtons.Contains(button))
            selectedButtons.Add(button);

        if (selectedButtons.Count == maxSelections)
            confirmButton.SetActive(true);
    }

    public void RemoveSelection(SelectableButton button)
    {
        if (selectedButtons.Contains(button))
            selectedButtons.Remove(button);

        confirmButton.SetActive(false);
    }
}
