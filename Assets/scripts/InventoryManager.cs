using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public Transform elementGrid; // Assign the Grid Layout Group in Inspector
    public List<Sprite> elementSpritesList; // Assign element sprites in Inspector
    public List<string> elementNamesList;  // Assign element names in Inspector

    private Dictionary<string, Sprite> elementSprites = new Dictionary<string, Sprite>(); // Name -> Sprite
    private Dictionary<string, Image> collectedSlots = new Dictionary<string, Image>(); // Name -> UI Image

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        InitializeSprites();
        InitializeTable();
    }

    // ✅ Step 1: Convert Lists into Dictionary for quick lookup
    void InitializeSprites()
    {
        for (int i = 0; i < elementNamesList.Count; i++)
        {
            if (i < elementSpritesList.Count)
            {
                elementSprites[elementNamesList[i]] = elementSpritesList[i];
            }
        }
        Debug.Log("Loaded " + elementSprites.Count + " element sprites.");
    }

    // ✅ Step 2: Find slot and child `elementImg` for each element
    void InitializeTable()
    {
        foreach (Transform slot in elementGrid)
        {
            string elementName = slot.name.Replace("_Slot", ""); // Ensure slot names match element names
            Image elementImg = slot.Find("elementImg")?.GetComponent<Image>(); // Get child Image component
            
            if (elementImg != null)
            {
                collectedSlots[elementName] = elementImg;
                elementImg.enabled = false; // Start hidden
            }
        }
        Debug.Log("Inventory initialized with " + collectedSlots.Count + " slots.");
    }

    // ✅ Step 3: When an element is collected, update child `elementImg`
    public void AddElement(string element)
    {
        if (collectedSlots.ContainsKey(element) && elementSprites.ContainsKey(element))
        {
            collectedSlots[element].sprite = elementSprites[element]; // Assign correct element sprite
            collectedSlots[element].enabled = true; // Make the image visible
            Debug.Log("Collected: " + element);
        }
        else
        {
            Debug.LogWarning("Slot or image not found for: " + element);
        }
    }
}
