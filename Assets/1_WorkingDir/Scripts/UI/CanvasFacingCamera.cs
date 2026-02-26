using UnityEngine;

namespace AR_Assessment.Ui
{
    public class CanvasFacingCamera : MonoBehaviour
    {
        [SerializeField]Camera m_Camera;

        void Start()
        {
            if (m_Camera == null)
                m_Camera = Camera.main;
        }

        void LateUpdate()
        {
            if (m_Camera == null)
                return;

            Vector3 direction = transform.position - m_Camera.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}