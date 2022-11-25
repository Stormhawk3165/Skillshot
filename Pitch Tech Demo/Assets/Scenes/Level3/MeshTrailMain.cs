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
        if (!isTrailActive)
        {
            isTrailActive = true;
            StartCoroutine(ActivateTrail(_activeTime));
        }
    }

    IEnumerator ActivateTrail(float timeActive)
    {
        while (timeActive > 0)
        {
            timeActive -= _meshRefreshRate;

            if (skinnedMeshRenderers == null)
            {
                skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
            }

            for (int i = 0; i < skinnedMeshRenderers.Length; i++)
            {
                GameObject gObj = new GameObject();
                MeshRenderer mr = gObj.AddComponent<MeshRenderer>();
                MeshFilter mf = gObj.AddComponent<MeshFilter>();
                Mesh mesh = new Mesh();
                skinnedMeshRenderers[i].BakeMesh(mesh);
                mf.mesh = mesh;
            }

            yield return new WaitForSeconds(meshRefreshRate);
        }

        isTrailActive = false;
    }
}