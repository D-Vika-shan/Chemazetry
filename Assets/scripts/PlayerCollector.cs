using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click to collect
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 3f))
            {
                Collectible collectible = hit.collider.GetComponent<Collectible>();
                if (collectible != null)
                {
                    InventoryManager.Instance.AddElement(collectible.elementName);
                    Destroy(hit.collider.gameObject); // Remove from scene
                }
            }
        }
    }
}
