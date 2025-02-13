using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile : MonoBehaviour
{
    public GameObject target;
    public float speed = 10f;
    public float rotationSpeed = 5f;
    public float wiggleSpeed = 5f;
    public float wiggleMagnitude = 5f;
    public int attackDamage = 1;
    public GameObject explosion;
    private bool exploded = false;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        speed += Random.Range(-2f,2f);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            // Rotate towards the target
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime));

            // Calculate the wiggle movement
            float wiggleAmount = Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude;
            Vector3 wiggleOffset = transform.right * wiggleAmount;

            // Calculate the final movement vector
            Vector3 movement = (transform.forward + wiggleOffset).normalized * speed;

            // Move forward with wiggle offset
            rb.MovePosition(rb.position + movement * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target && !exploded)
        {
            exploded = true;
            target.GetComponent<PlayerStats>().TakeDamage(attackDamage);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        } else if (other.tag == "Arrow" && !exploded)
        {
            exploded = true;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}