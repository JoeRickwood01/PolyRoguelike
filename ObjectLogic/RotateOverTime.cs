using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    float y = 0f;
    [SerializeField] private Vector3 axis;
    [SerializeField] private float speed;

    private void Update()
    {
        y += Time.deltaTime * speed;
        transform.localRotation = Quaternion.Euler(axis.x * y, axis.y * y, axis.z * y);
    }

}
