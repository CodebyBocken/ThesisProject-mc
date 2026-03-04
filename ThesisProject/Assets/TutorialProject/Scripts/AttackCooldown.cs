using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackCooldown : MonoBehaviour
{
    [SerializeField] TMP_Text textCooldown;
    private Image attackCooldownImage;

    private float cooldownTimer;
    private float maxCooldown;
    // Start is called before the first frame update
    void Start()
    {
        attackCooldownImage = GetComponent<Image>();
        attackCooldownImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            textCooldown.text = "";
            cooldownTimer -= Time.deltaTime;
            attackCooldownImage.fillAmount = cooldownTimer / maxCooldown;
        }
        else
        {
            attackCooldownImage.fillAmount = 0;
            textCooldown.text = "Attack Ready!";
        }
    }

    public void StartCooldown(float cooldown)
    {
        maxCooldown = cooldown;
        cooldownTimer = cooldown;
    }
}
