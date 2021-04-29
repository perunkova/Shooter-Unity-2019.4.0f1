using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _playerAgent;

    public PlayerSettings PlayerSettings;

    public void Move(Vector3 targetPosition)
    {
        _playerAgent.speed = PlayerSettings.PlayerSpeed;
        _playerAgent.SetDestination(targetPosition);
    }
}
