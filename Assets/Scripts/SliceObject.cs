using UnityEngine;
using EzySlice;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;

public class SliceObject : MonoBehaviour
{
    public Transform startSlicePoint;
    public Transform endSlicePoint;
    public Material sectionMaterial;
    public float cutForce = 2000f;
    public LayerMask sliceableLayer;
    public VelocityEstimator velocityEstimator;

    void FixedUpdate()
    {
        bool hasHit = Physics.Linecast(startSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        if (hasHit)
        {
            //AudioManager.instance.Play("Cut");
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }

    }
    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - startSlicePoint.position, velocity);
        planeNormal.Normalize();
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);
        if (hull != null)
        {
            GameObject upperHull = hull.CreateUpperHull(target, sectionMaterial);
            SetupSlicedComponent(upperHull);
            GameObject lowerHull = hull.CreateLowerHull(target, sectionMaterial);
            SetupSlicedComponent(lowerHull);
            Destroy(target);
        }
      
    }
    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
        StartCoroutine(ReduceObject(slicedObject));

    }
    IEnumerator ReduceObject(GameObject slicedObject)
    {
        yield return new WaitForSeconds(1f);
        slicedObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, Vector3.zero, .5f * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        Destroy(slicedObject);
    }
}
