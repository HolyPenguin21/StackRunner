using UnityEngine;

public class RagdollComponent
{
    Transform meshTransform;
    Rigidbody meshRigidbody;
    BoxCollider meshboxCollider;

    Rigidbody[] rigidbodies;
    BoxCollider[] boxColliders;
    CapsuleCollider[] capsuleColliders;
    SphereCollider[] sphereColliders;

    public RagdollComponent(Transform meshTransform, IGameStateEvents gameStateEvents)
    {
        this.meshTransform = meshTransform;
        meshRigidbody = meshTransform.GetComponent<Rigidbody>();
        meshboxCollider = meshTransform.GetComponent<BoxCollider>();

        Set_Rigidbodies();
        Set_Colliders();

        DisableRagdoll();

        gameStateEvents.Add_GameEndListener(EnableRagdoll);
        gameStateEvents.Add_GameRestartListener(DisableRagdoll);
    }

    private void Set_Rigidbodies()
    {
        if (rigidbodies == null)
            rigidbodies = meshTransform.GetComponentsInChildren<Rigidbody>();
    }

    private void Set_Colliders()
    {
        boxColliders = meshTransform.GetComponentsInChildren<BoxCollider>();
        capsuleColliders = meshTransform.GetComponentsInChildren<CapsuleCollider>();
        sphereColliders = meshTransform.GetComponentsInChildren<SphereCollider>();
    }

    private void DisableRagdoll()
    {
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            if (rigidbodies[i].transform == meshTransform) continue;

            rigidbodies[i].isKinematic = true;
        }

        for (int i = 0; i < boxColliders.Length; i++)
        {
            if (boxColliders[i].transform == meshTransform) continue;

            boxColliders[i].enabled = false;
        }

        for (int i = 0; i < capsuleColliders.Length; i++)
        {
            if (capsuleColliders[i].transform == meshTransform) continue;

            capsuleColliders[i].enabled = false;
        }

        for (int i = 0; i < sphereColliders.Length; i++)
        {
            if (sphereColliders[i].transform == meshTransform) continue;

            sphereColliders[i].enabled = false;
        }

        meshRigidbody.isKinematic = false;
        meshboxCollider.enabled = true;
    }

    private void EnableRagdoll()
    {
        for (int i = 0; i < rigidbodies.Length; i++)
            rigidbodies[i].isKinematic = false;

        for (int i = 0; i < boxColliders.Length; i++)
            boxColliders[i].enabled = true;

        for (int i = 0; i < capsuleColliders.Length; i++)
            capsuleColliders[i].enabled = true;

        for (int i = 0; i < sphereColliders.Length; i++)
            sphereColliders[i].enabled = true;

        meshRigidbody.isKinematic = true;
        meshboxCollider.enabled = false;
    }
}
