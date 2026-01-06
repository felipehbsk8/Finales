using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 200f;
    [SerializeField] private float minPitch = -35f;
    [SerializeField] private float maxPitch = 35f;

    [Header("Camera collision")]
    private float _cameraDistance = 3f;
    private float _collisionRadius = 0.2f;
    public LayerMask collisionMask;

    private float pitch;
    private Transform cameraTransform;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        GameManager.Instance.LockCursorAndSetVisible(false);
    }

    private void Update()
    {
        HandleLook();
        HandleCollision();
    }

    private void HandleCollision()
    {
        Vector3 pivotPos = transform.position;
        Vector3 desiredPos = pivotPos - transform.forward * _cameraDistance;

        if (Physics.SphereCast(pivotPos, _collisionRadius, -transform.forward, out RaycastHit hit, _cameraDistance, collisionMask, QueryTriggerInteraction.Ignore))
        {
            cameraTransform.position = pivotPos - transform.forward * hit.distance;
        }
        else
        {
            cameraTransform.position = desiredPos;
        }

    }

    private void HandleLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}
