using UnityEngine;

public class ShowModelUI : MonoBehaviour
{
    [SerializeField] private ShowModelButton buttonPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var models = FindObjectOfType<ShowModelController>().GetModels();
        foreach (var model in models)
        {
            CreateButtonForModel(model);
        }
    }

    private void CreateButtonForModel(Transform model)
    {
        var button = Instantiate(buttonPrefab);
        button.transform.SetParent(this.transform);
        button.transform.localScale = Vector3.one;
        button.transform.localRotation = Quaternion.identity;

        button.Initialize(model, FindObjectOfType<ShowModelController>().EnableModel);
    }
}
