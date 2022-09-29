using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private NPC npc = null;
    [SerializeField]
    private SphereCollider sphereCollider = null;

    private void Awake()
    {
        npc = GetComponent<NPC>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("npc ontrigger enter");
            UIManager.Instance.SetReadyDialogue(npc.ListDialogueData[0], transform);
            UIManager.Instance.SetActiveInteractionButton(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("npc ontrigger exit");
            UIManager.Instance.SetReadyDialogue(null, null);
            UIManager.Instance.SetActiveInteractionButton(false);
        }
    }
}
