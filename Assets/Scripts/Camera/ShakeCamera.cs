using System.Collections;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField]
    private float shakePower = 10f;
    private float remainShakeTime = 0f;
    private bool isStayCoroutine = false;

    public void ShakeCameraAction()
    {
        if (!isStayCoroutine) StartCoroutine(nameof(ShakeByRotation), 1.5f);
    }

    private IEnumerator ShakeByRotation(float shakeTime)
    {
        isStayCoroutine = true;

        print("ShakeCamera");
        Vector3 originRotation = transform.eulerAngles;
        remainShakeTime = shakeTime;

        while (!GameManager.Instance.IsGameover && remainShakeTime > 0)
        {
            float x = Random.Range(-2f, 2f);
            float y = Random.Range(-2f, 2f);
            float z = Random.Range(-2f, 2f);
            transform.rotation = Quaternion.Euler(originRotation + new Vector3(x, y, z) * shakePower);

            remainShakeTime -= Time.deltaTime;

            yield return null;
        }
        transform.rotation = Quaternion.Euler(originRotation);

        isStayCoroutine = false;
    }
}
