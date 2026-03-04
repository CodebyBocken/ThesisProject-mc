using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Camera mainCamera;
    private Image healthBarImage;
    public Gradient ColorGradient;

    // Start is called before the first frame update
    private void Start()
    {
        healthBarImage = GetComponent<Image>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.LookAt(mainCamera.transform, Vector3.up);
    }

    public void UpdateHealthBar(float healthLeft)
    {
        healthBarImage.fillAmount = healthLeft;
        healthBarImage.color = ColorGradient.Evaluate(healthBarImage.fillAmount);
    }
}
