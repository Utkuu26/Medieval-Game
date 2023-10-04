using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamagePopUp : MonoBehaviour
{
    public TMP_Text text;
    public float lifetime = 1.5f;
    public float moveSpeed = 1.0f; 
    public float fadeOutDuration = 0.5f; 
    
    private float timer;

    private Vector3 initialPosition;
    private Vector3 targetPosition;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector3.up;
        transform.localScale = Vector3.zero;
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        transform.position = Vector3.Lerp(initialPosition, targetPosition, timer / lifetime);

        if (timer > lifetime)
        {
            float alpha = Mathf.Lerp(1f, 0f, (timer - lifetime) / fadeOutDuration);
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);

            if (alpha <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetDamageText(int damage)
    {
        text.text = damage.ToString();
    }
}
