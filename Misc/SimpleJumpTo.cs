using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class SimpleJumpTo : MonoBehaviour
{
    public Transform target;
    public int jumpCount = 1;
    public float jumpPower = 1f;
    public float duration = 1f;

    public void PlayAnimation()
    {

        ResetRigidbody();
        transform.DOJump(target.position, jumpPower, jumpCount, duration, false);
    }

    private IEnumerator ResetRigidbody()
    {
        yield return new WaitForSeconds(duration);
        Rigidbody rb;
        if (TryGetComponent<Rigidbody>(out rb))
        {
            rb.velocity = Vector3.zero;
        }
    }
}
