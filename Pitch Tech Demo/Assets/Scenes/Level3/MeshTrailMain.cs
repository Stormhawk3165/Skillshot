using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTrailMain : MonoBehaviour
{

    [SerializeField] private float _activeTime = 2f;
    [SerializeField] private float _meshRefreshRate = 0.1f;
    [SerializeField] private MeshRenderer _meshToCreate;
    [SerializeField] private bool _isMoving;


    private bool isTrailActive;

    private void Start()
    {
        isTrailActive = false;
    }

    private void Update()
    {
        if (isTrailActive == false)
        {
            isTrailActive = true;
        }
    }
}