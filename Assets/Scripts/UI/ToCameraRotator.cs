using UnityEngine;

public class ToCameraRotator : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.LookAt(transform.position + _target.forward);
    }
}
