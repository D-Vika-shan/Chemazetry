using UnityEngine;

public class RotateModel : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 50f * Time.deltaTime);
    }
}
