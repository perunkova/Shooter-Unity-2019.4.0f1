using UnityEngine;

public class PlayerMoveController : BasePlayerController
{
    [SerializeField] private Player _player;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                _player.Move(hit.point);
              
#if UNITY_EDITOR
            Debug.DrawRay(ray.origin,ray.direction*100,Color.green, 1);
#endif
        }
    }
}
