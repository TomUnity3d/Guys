using UnityEngine;
using TMPro; // for TextMeshPro

public class respawn : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(0, 2, 0);
    public TextMeshProUGUI deathCounterText; // assign in Inspector

    private int deathCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Player must be tagged "Player"
        {
            // Add 1 to death counter
            deathCount++;
            UpdateDeathUI();

            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
                other.transform.position = respawnPosition;
                cc.enabled = true;
            }
            else
            {
                other.transform.position = respawnPosition;
            }
        }
    }

    private void UpdateDeathUI()
    {
        if (deathCounterText != null)
        {
            deathCounterText.text = "Deaths: " + deathCount;
        }
    }
}