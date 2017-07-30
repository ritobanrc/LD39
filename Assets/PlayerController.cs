using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float MaxVelocity = 5f;
    public float Acceleration = 3f;
    public Fuel fuel;
    public GameObject explosionPrefab;
    public AudioClip ExplosionClip;

    float velocity = 0;
    int lane = 0;
    bool started = false;
    private void Update()
    {
        if (exploding)
            return;
        float dv = Input.GetAxis("Vertical");
        dv = Mathf.Max(0, dv);
        dv = dv * ((MaxVelocity - dv) / MaxVelocity);
        if (dv > 0.01 && started == false)
        {
            FindObjectOfType<Canvas>().GetComponent<Animator>().SetTrigger("Start");
        }
        velocity += dv * Acceleration * Time.deltaTime;
        velocity = Mathf.Min(velocity, MaxVelocity);
        this.transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        fuel.fuel -= Time.deltaTime;

        float dx = Input.GetAxisRaw("Horizontal");

        if (dx < -0.5 && lane > -1 && moving == false)
        {
            lane--;
            moving = true;
            fuel.fuel -= 1;
            StartCoroutine(MoveLeft());
        }
        else if (dx > 0.5 && lane < 1 && moving == false)
        {
            lane++;
            moving = true;
            fuel.fuel -= 1;

            StartCoroutine(MoveRight());
        }
        if (fuel.fuel <= 0)
        {
            Explode();
        }
    }
    bool exploding;
    Vector3 lateralVel = Vector3.zero;
    bool moving = false;

    public void Explode()
    {
        if (exploding)
            return;
        AudioSource.PlayClipAtPoint(ExplosionClip, Camera.main.transform.position);
        exploding = true;
        Instantiate(explosionPrefab, this.transform.position, explosionPrefab.transform.rotation);
        FindObjectOfType<Canvas>().GetComponent<Animator>().SetTrigger("End");
        FindObjectOfType<ScoreText_EndScreen>().StartDisplay();
    }

    private IEnumerator MoveRight()
    {
        while (Mathf.Abs(this.transform.position.x - lane) > 0.01)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(lane, this.transform.position.y, this.transform.position.z), ref lateralVel, 0.1f);
            yield return null;
        }
        moving = false;
    }

    private IEnumerator MoveLeft()
    {
        while (Mathf.Abs(this.transform.position.x - lane) > 0.01)
        {
            this.transform.position = Vector3.SmoothDamp(this.transform.position, new Vector3(lane, this.transform.position.y, this.transform.position.z), ref lateralVel, 0.1f);
            yield return null;
        }
        moving = false;

    }
}
