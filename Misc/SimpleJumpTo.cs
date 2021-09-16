using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;

public class SimpleJumpTo : MonoBehaviour
{
    [Header("Jump Options")]
    public Transform target;
    public int jumpCount = 1;
    public float jumpPower = 1f;
    public float duration = 1f;

    public UnityEvent OnStartJump = new UnityEvent();
    public UnityEvent OnFinishJump = new UnityEvent();

    public void PlayAnimation()
    {

        ResetRigidbody();
        transform.DOJump(target.position, jumpPower, jumpCount, duration, false);
        OnStartJump.Invoke();
    }

    private IEnumerator ResetRigidbody()
    {
        yield return new WaitForSeconds(duration);
        Rigidbody rb;
        if (TryGetComponent<Rigidbody>(out rb))
        {
            rb.velocity = Vector3.zero;
        }
        OnFinishJump.Invoke();
    }
}
