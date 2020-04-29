﻿using UnityEngine;

public class Figure : MonoBehaviour
{
    private float maxScale = 2f;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        ChangesFigure();
    }

    private void ChangesFigure()
    {
        _meshRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        float randomScale = Random.Range(0.5f, maxScale);
        transform.localScale += new Vector3(randomScale, randomScale, randomScale);
    }
}
