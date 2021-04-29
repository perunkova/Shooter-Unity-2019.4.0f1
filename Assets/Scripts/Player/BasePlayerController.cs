using UnityEngine;

public abstract class BasePlayerController : MonoBehaviour
{
    [SerializeField] protected Camera _camera;

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
