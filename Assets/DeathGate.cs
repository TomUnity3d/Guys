using UnityEngine;

public class DeathGate : MonoBehaviour
{
    [SerializeField] private KillFloor killFloor; // reference to your KillFloor script

    void Update()
    {
        if (killFloor != null && killFloor.DeathCount > 3)
        {
            // Hide + disable this gate object
            gameObject.SetActive(false);
        }
    }
}