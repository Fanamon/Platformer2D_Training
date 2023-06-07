using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] LayerMask _groundLayer;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((_groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            _isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((_groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            _isGrounded = false;
        }
    }
}
