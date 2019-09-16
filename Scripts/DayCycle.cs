using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public float DayCycleSpeed;
    private void Start() => StartCoroutine(nameof(RotateSun));

    IEnumerator RotateSun() {
        while (enabled)
        {
            transform.Rotate(new Vector3(1, 0, 0), DayCycleSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
