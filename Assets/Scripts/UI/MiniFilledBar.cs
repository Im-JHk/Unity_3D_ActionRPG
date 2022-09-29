using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniFilledBar : MonoBehaviour
{
    [SerializeField]
    private MonsterStat monsterStat = null;
    [SerializeField]
    private Image hpBarImage;
    [SerializeField]
    private Transform cameraTransform = null;

    private void Awake()
    {
        if (monsterStat == null) monsterStat = GetComponentInParent<MonsterStat>();
        if (cameraTransform == null) cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        hpBarImage.fillAmount = (float)monsterStat.Hp / (float)monsterStat.Data.Hp;
        transform.LookAt(transform.position + cameraTransform.rotation * Vector3.forward, cameraTransform.rotation * Vector3.up);
    }
}
