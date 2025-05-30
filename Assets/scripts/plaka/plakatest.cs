using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plakatest : MonoBehaviour
{   // Kutunun bir Trigger alanına girdiğinde tetiklenecek olay
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Çarpılan nesne: " + other.gameObject.name);
        if (other.CompareTag("Respawn"))
        {
            Debug.Log("Kutuyu doğru yere ittiniz! Olay tetiklendi.");
            // Burada istediğiniz olayları gerçekleştirin
        }
    }
}
