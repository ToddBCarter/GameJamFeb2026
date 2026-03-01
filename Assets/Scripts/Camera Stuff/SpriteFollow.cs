using UnityEngine;

public class SpriteFollow : MonoBehaviour
{
    [SerializeField] private Camera targetCamera;

    private void LateUpdate()
    {
        if (targetCamera != null)
        {
            Vector3 lookDir = transform.position - targetCamera.transform.position;

            lookDir.y = 0f;

            if (lookDir.sqrMagnitude > 0.001f)
            {
                transform.rotation = Quaternion.LookRotation(lookDir);
            }
        }
    }
}