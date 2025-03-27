using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ElementInfoPanel : MonoBehaviour
{
    public static ElementInfoPanel Instance;

    public GameObject panel;  // Reference to ElementInfoPanel
    public Image elementImage; // UI Image to display element picture
    public TextMeshProUGUI elementDescription;  // Text field for element info

    // Dictionary to map element names to their images
    public Dictionary<string, Sprite> elementSprites = new Dictionary<string, Sprite>();

    void Awake()
    {
        if (Instance == null) Instance = this;
        panel.SetActive(false);  // Hide the panel initially

        LoadElementSprites(); // Load all element images
    }

    public void ShowElementInfo(string elementName)
    {
        panel.SetActive(true);  // Show the panel

        // Load and display the element image
        if (elementSprites.ContainsKey(elementName))
        {
            elementImage.sprite = elementSprites[elementName];
            elementImage.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No image found for element: " + elementName);
        }

        // Set the element description
        elementDescription.text = GetElementDescription(elementName);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        elementImage.gameObject.SetActive(false); // Hide the image when closing
    }

    private string GetElementDescription(string elementName)
    {
        switch (elementName)
        {
            case "H": return "Hydrogen: The lightest element, used in fuel cells.";
            case "O": return "Oxygen: Essential for respiration and combustion.";
            case "Na": return "Sodium: Highly reactive metal, found in salt.";
            default: return "Unknown Element";
        }
    }

    private void LoadElementSprites()
    {
        // Load all element images from Resources/Images folder
        Sprite[] sprites = Resources.LoadAll<Sprite>("Images");

        foreach (Sprite sprite in sprites)
        {
            elementSprites[sprite.name] = sprite;
        }
    }
}
