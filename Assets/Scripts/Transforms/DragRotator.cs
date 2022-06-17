using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Utilities;

namespace DungeonTitans
{
    public class DragRotator : MonoBehaviour
    {
        [SerializeField] private float xRotationSpeed;
        [SerializeField] private float yRotationSpeed;
        [SerializeField] private bool invertX;
        [SerializeField] private bool invertY;
        [SerializeField] private bool returnOnRelease;

        private DragHandler dragHandler;
        private Quaternion startRotation;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            startRotation = transform.rotation;

            dragHandler = GetComponent<DragHandler>();
        }

        private void OnEnable()
        {
            dragHandler.onBeginDrag += (v) => StopCoroutine();
            dragHandler.onDrag += Rotate;
            dragHandler.onEndDrag += (v) => ReturnRotation();
        }

        private void OnDisable()
        {
            dragHandler.onBeginDrag -= (v) => StopCoroutine();
            dragHandler.onDrag -= Rotate;
            dragHandler.onEndDrag -= (v) => ReturnRotation();
        }

        private void Rotate(Vector2 direction)
        {
            if(yRotationSpeed != 0)
            {
                if(invertY) direction.x = -direction.x;
                Vector3 yRotation = new Vector3(0, direction.x * Time.deltaTime * yRotationSpeed, 0);
                transform.Rotate(yRotation, Space.World);
            }
            
            if(xRotationSpeed != 0)
            {
                if(invertX) direction.y = -direction.y;
                Vector3 xRotation = new Vector3(direction.y * Time.deltaTime * xRotationSpeed, 0, 0);
                transform.Rotate(xRotation, Space.Self);
            }
            
        }

        private void ReturnRotation()
        {
            if(!returnOnRelease) return;

            StopCoroutine();
            StartCoroutine(ReturnRotationCoroutine());
        }

        private IEnumerator ReturnRotationCoroutine()
        {
            Quaternion currentRotation = transform.rotation;
            
            float t = 0;
            while(t < 1)
            {
                t += Time.deltaTime * 4;
                transform.rotation = Quaternion.Lerp(currentRotation, startRotation, t);
                yield return null;
            }
        }

        private void StopCoroutine()
        {
            StopAllCoroutines();
        }
    }
}
