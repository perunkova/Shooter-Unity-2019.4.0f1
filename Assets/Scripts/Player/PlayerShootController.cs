using UnityEngine;

public class PlayerShootController : BasePlayerController
{
    [SerializeField] private Hand _hand;

    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        _hand.LookTo(ray.direction);

        if (Input.GetMouseButtonDown(0))
            _hand.StartShoot();

        if (Input.GetMouseButtonUp(0))
            _hand.StopShoot();
    }
}

