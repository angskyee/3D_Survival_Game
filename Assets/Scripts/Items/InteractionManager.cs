using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface IInteractable
{
    string GetInteractPrompt();
    void OnInteract();
}
public class InteractionManager : MonoBehaviour
{
    public float checkLate = 0.05f;
    private float lastCheckTIme;
    public float maxCheckDistance;
    public LayerMask layerMask;

    private GameObject curInteractGameObject;
    private IInteractable curInteractable;

    public TextMeshProUGUI promptText;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Time.time - lastCheckTIme > checkLate)
        {
            lastCheckTIme = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = string.Format("<b>[E]</b> {0}", curInteractable.GetInteractPrompt());
    }
}
