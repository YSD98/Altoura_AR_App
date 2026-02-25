using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class GlbModelSpawner : MonoBehaviour
{
    [SerializeField]GameObject m_ObjectPrefab;

    [SerializeField]bool m_OnlySpawnInView = true;

    [SerializeField]float m_ViewportPeriphery = 0.15f;

    [SerializeField]bool m_ApplyRandomAngleAtSpawn = true;

    [SerializeField]float m_SpawnAngleRange = 45f;

    [SerializeField]bool m_SpawnAsChildren;

    bool m_HasSpawned = false;
    Camera m_CameraToFace;

    public event Action<GameObject> objectSpawned;

    void Awake()
    {
        EnsureFacingCamera();
    }

    void EnsureFacingCamera()
    {
        if (m_CameraToFace == null)
            m_CameraToFace = Camera.main;
    }

    public bool TrySpawnObject(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        if (m_HasSpawned)
            return false;

        if (m_ObjectPrefab == null)
            return false;

        if (m_OnlySpawnInView)
        {
            var inViewMin = m_ViewportPeriphery;
            var inViewMax = 1f - m_ViewportPeriphery;
            var pointInViewportSpace = m_CameraToFace.WorldToViewportPoint(spawnPoint);

            if (pointInViewportSpace.z < 0f ||
                pointInViewportSpace.x > inViewMax || pointInViewportSpace.x < inViewMin ||
                pointInViewportSpace.y > inViewMax || pointInViewportSpace.y < inViewMin)
                return false;
        }

        var newObject = Instantiate(m_ObjectPrefab);

        if (m_SpawnAsChildren)
            newObject.transform.SetParent(transform);

        newObject.transform.position = spawnPoint;

        var facePosition = m_CameraToFace.transform.position;
        var forward = facePosition - spawnPoint;
        BurstMathUtility.ProjectOnPlane(forward, spawnNormal, out var projectedForward);
        newObject.transform.rotation = Quaternion.LookRotation(projectedForward, spawnNormal);

        if (m_ApplyRandomAngleAtSpawn)
        {
            var randomRotation = UnityEngine.Random.Range(-m_SpawnAngleRange, m_SpawnAngleRange);
            newObject.transform.Rotate(Vector3.up, randomRotation);
        }

        m_HasSpawned = true;
        objectSpawned?.Invoke(newObject);

        return true;
    }

    public void SpawnObject(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        TrySpawnObject(spawnPoint, spawnNormal);
    }
}