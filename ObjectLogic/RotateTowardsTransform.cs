using UnityEngine;

public class RotateTowardsTransform : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotateSpeed;

    private void Update()
    {
        Vector3 position = target.position;
        Vector3 direction = (position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion toQuaternion = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, toQuaternion, Time.deltaTime * rotateSpeed);
    }

}
