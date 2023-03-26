using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitStates
{
    Default,
    OnAir,
    OnPlatform,
    OnGround,
    Shrinked
}
public abstract class UnitBaseBehaviour : MonoBehaviour
{
    public UnitStates state;

    protected Rigidbody rb;
    protected Vector3 defaultSize;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected float shrinkedSizeVert = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        state = UnitStates.OnAir;
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    public void HitSide(Vector3 direction)
    {
        rb.AddForce(direction * jumpForce, ForceMode.Impulse);
    }

    public void Shrink()
    {
        state = UnitStates.Shrinked;
        transform.localScale = new Vector3(transform.localScale.x, shrinkedSizeVert, transform.localScale.z);
    }

    public void Enlarge()
    {
        state = UnitStates.OnPlatform;
        transform.localScale = defaultSize;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.CompareTag("Platform"))
        {
            state = UnitStates.OnPlatform;
        }
        if(collision.transform.CompareTag("Ground"))
        {
            state = UnitStates.OnGround;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var colliderParent = other.transform.parent;
        if(colliderParent && colliderParent.CompareTag("Mechanism"))
        {
            var hitDirection = Vector3.Normalize(other.ClosestPoint(transform.position) - transform.position);
            HitSide(hitDirection);
        }
    }

}
