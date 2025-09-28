using TMPro;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public TextMeshProUGUI deathCounterText; // Link your UI text here
    private int deathCount = 0;

    // Called when player touches a "bad" object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            RespawnPlayer();
        }
    }

    // Teleport player safely and update death counter
    private void RespawnPlayer()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Stop any falling or spinning
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Teleport slightly above the floor to prevent falling through
        transform.position = new Vector3(0f, 1f, 0f);

        // Update death count
        deathCount++;
        if (deathCounterText != null)
            deathCounterText.text = "Deaths: " + deathCount;
    }
}