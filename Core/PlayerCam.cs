using UnityEngine;
using UnityEngine.U2D;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private Camera playerCam;

    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;

    float sight;

    private void Start()
    {
        sight = PlayerStats.Instance.sight;
        playerCam.orthographicSize = Mathf.RoundToInt(sight);

        if (playerCam == null)
        {
            playerCam = Camera.main;
        }
    }

    private void Update()
    {
        sight = Mathf.Lerp(sight, PlayerStats.Instance.sight, Time.deltaTime);
        playerCam.orthographicSize = sight;

        Vector3 relativeOffset = playerCam.ScreenToWorldPoint(Input.mousePosition) - target.position;
        relativeOffset.x = Mathf.Clamp(relativeOffset.x / 5f, -1f, 2f);
        relativeOffset.y = Mathf.Clamp(relativeOffset.y / 5f, -1f, 2f);
        relativeOffset.z = 0;

        Vector3 targetPos = target.position + relativeOffset + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
    }

}
