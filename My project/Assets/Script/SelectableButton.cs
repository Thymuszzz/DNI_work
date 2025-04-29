using UnityEngine;
using UnityEngine.UI;

public class SelectableButton : MonoBehaviour
{
    private bool isSelected = false;
    private Button button;
    private Image image;
    private SelectionManager manager;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color selectedColor = Color.red;

    private void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        manager = FindObjectOfType<SelectionManager>();

        button.onClick.AddListener(OnClick);
        UpdateVisual();
    }

    private void OnClick()
    {
        if (!isSelected && manager.CanSelect())
        {
            isSelected = true;
            manager.AddSelection(this);
        }
        else if (isSelected)
        {
            isSelected = false;
            manager.RemoveSelection(this);
        }

        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (image != null)
            image.color = isSelected ? selectedColor : normalColor;
    }

    public bool IsSelected => isSelected;
}
