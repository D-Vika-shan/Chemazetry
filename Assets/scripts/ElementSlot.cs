using UnityEngine;
using UnityEngine.UI;

public class ElementSlot : MonoBehaviour
{
    public string elementName;  // Store the element's name
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnElementClicked);
    }

    void OnElementClicked()
    {
        ElementInfoPanel.Instance.ShowElementInfo(elementName);
    }
}
