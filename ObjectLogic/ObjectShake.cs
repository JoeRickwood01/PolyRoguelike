using System.Collections;
using UnityEngine;

public class ObjectShake : MonoBehaviour
{
    [SerializeField] private Transform shakeTransform;

    public void Shake(float duration, float size, Vector3 axis)
    {
        StartCoroutine(ShakeObject(duration, size, axis));
    }

    private IEnumerator ShakeObject(float duration, float size, Vector3 axis)
    {
        float elapsed = duration;
        Vector3 origionalPositon = shakeTransform.localPosition;

        while (elapsed > 0)
        {
            float x = Random.Range(-1f, 1f) * size;
            float y = Random.Range(-1f, 1f) * size;
            float z = Random.Range(-1f, 1f) * size;

            Vector3 pos = new Vector3(x * axis.x, y * axis.y, z * axis.z); 
            shakeTransform.localPosition = pos;

            elapsed -= Time.deltaTime;

            yield return null;
        }
    }
}
