using UnityEngine;
using TMPro;

public class KillFloor : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private TextMeshProUGUI deathText;

    private CharacterController cc;
    private int deathCount = 0;

    // 👇 this exposes the counter to other scripts
    public int DeathCount => deathCount;

    private void Start()
    {
        cc = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            cc.enabled = false;
            player.position = respawnPoint.position;
            cc.enabled = true;

            deathCount++;
            if (deathText != null)
                deathText.text = "Deaths: " + deathCount;
        }
    }
}