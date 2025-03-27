using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeriodicTableUI : MonoBehaviour
{
    public GameObject periodicTablePanel;
    public Button inventoryButton;
    public Button closeButton;
    private Dictionary<string, Image> elementSlots = new Dictionary<string, Image>();

    void Start()
    {
        // Unlock the cursor permanently
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (inventoryButton != null)
        {
            inventoryButton.onClick.AddListener(TogglePeriodicTable);
            Debug.Log("✅ Button listener added successfully!");
        }
        else
        {
            Debug.LogError("❌ Inventory button is NOT assigned in the Inspector!");
        }

        periodicTablePanel.SetActive(false);
    }

    public void TogglePeriodicTable()
    {
        if (periodicTablePanel == null)
        {
            Debug.LogError("❌ Periodic Table Panel is NOT assigned!");
            return;
        }

        // Prevent multiple quick toggles
        CancelInvoke(); // Cancel any pending invoke
        Invoke(nameof(TogglePanel), 0.1f); // Delay to prevent multiple toggles in one frame
    }

    void TogglePanel()
    {
        bool isActive = !periodicTablePanel.activeSelf;
        periodicTablePanel.SetActive(isActive);
        Debug.Log("🔵 Inventory Active: " + isActive);
    }



    public void UpdatePeriodicTable(string element, GameObject modelPrefab)
    {
        if (elementSlots.ContainsKey(element))
        {
            Image slotImage = elementSlots[element];

            // Remove old placeholder text/image
            foreach (Transform child in slotImage.transform)
            {
                Destroy(child.gameObject);
            }

            // Create 3D model preview inside the slot
            GameObject modelPreview = Instantiate(modelPrefab, slotImage.transform);
            modelPreview.transform.localPosition = Vector3.zero;
            modelPreview.transform.localScale = Vector3.one * 50f; // Scale down for UI

            // Disable physics components
            Destroy(modelPreview.GetComponent<Rigidbody>());
            Destroy(modelPreview.GetComponent<Collider>());

            // Change UI color to indicate it's collected
            slotImage.color = Color.green;
        }
    }

    public void CloseInventory()
    {
        periodicTablePanel.SetActive(false);
        Debug.Log("🔴 Inventory Closed");
    }
}
