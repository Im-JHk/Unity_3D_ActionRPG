using System.Collections;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public enum CameraFollowType
    {
        Continue = 0,
        Moment
    }

    [SerializeField]
    private Transform target = null;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private Vector3 rotate;
    [SerializeField]
    private float smoothTime;

    private float elapsedMoveTime;
    private float maxMoveTime;
    private bool isStayCoroutine;

    public CameraFollowType FollowType { get; set; }

    void Awake()
    {
        offset = new Vector3(0f, 6f, -10f);
        rotate = new Vector3(30f, 0f, 0f);
        transform.eulerAngles = rotate;
        smoothTime = 3f;
        elapsedMoveTime = 0f;
        maxMoveTime = 1f;
        isStayCoroutine = false;
        FollowType = CameraFollowType.Continue;
    }

    void LateUpdate()
    {
        if(target != null && FollowType == CameraFollowType.Continue)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime * Time.deltaTime);
        }
    }

    public void FollowCameraToTarget(Transform target)
    {
        if (!isStayCoroutine) StartCoroutine(nameof(FollowMoveToTarget), target);
    }

    private IEnumerator FollowMoveToTarget(Transform target)
    {
        isStayCoroutine = true;
        FollowType = CameraFollowType.Moment;

        elapsedMoveTime = 0f;
        while (elapsedMoveTime < maxMoveTime)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, elapsedMoveTime / maxMoveTime);
            elapsedMoveTime += Time.deltaTime;
            yield return null;
        }
        transform.position = target.transform.position + offset;

        isStayCoroutine = false;
        FollowType = CameraFollowType.Continue;
    }
}
