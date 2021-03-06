﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{
	public List<Waypoint> wayPoints = new List<Waypoint>();
	public float speed = 3f;

	public bool isCircular;

	// Always true at the beginning because the moving object will always move towards the first waypoint
	public bool inReverse = true;
	public bool isChasing = false;


	private Waypoint currentWaypoint;
	private ParticleSystem ps;
	private int currentIndex = 0;
	private bool isWaiting = false;
	private float speedStorage = 0;
	private bool stillChasing = false;
	public Vector3 currentPosition;
	public Vector3 targetPosition;
	public Vector3 vectorToTarget;
	public Vector3 directionOfTravel;

	private Animator anim;
	
	IEnumerator ChaseTime(float time)
	{
		anim.SetBool("isChasing", true);
		ps.Play();
		stillChasing = true;
		yield return new WaitForSeconds(time);
		isChasing = false;
		stillChasing = false;
		anim.SetBool("isChasing", false);
	}

	/**
	 * Initialisation
	 * 
	 */
	void Start()
	{
		ps = GetComponent<ParticleSystem>();
		ps.Stop();
		anim = GetComponent<Animator>();
		anim.SetBool("isMoving", true);
		if (wayPoints.Count > 0)
		{
			currentWaypoint = wayPoints[0];
		}
	}



	/**
	 * Update is called once per frame
	 * 
	 */
	void Update()
	{
		if (currentWaypoint != null && !isWaiting && !isChasing)
		{
			ps.Stop();
			MoveTowardsWaypoint();
		}
		else if (isChasing)
		{
			PlayerDetection();
		}
	}

	/**
	 * Pause the mover
	 * 
	 */
	public void Pause()
	{
		isWaiting = !isWaiting;
	}



	/**
	 * Move the object towards the selected waypoint
	 * 
	 */
	public void MoveTowardsWaypoint()
	{
		// Get the moving objects current position
		currentPosition = this.transform.position;
		// Get the target waypoints position
		targetPosition = currentWaypoint.transform.position;

		vectorToTarget = targetPosition - currentPosition;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 1000f);
		// If the moving object isn't that close to the waypoint
		if (Vector3.Distance(currentPosition, targetPosition) > .1f)
		{

			// Get the direction and normalize
			directionOfTravel = targetPosition - currentPosition;
			directionOfTravel.Normalize();

			//scale the movement on each axis by the directionOfTravel vector components
			this.transform.Translate(
				directionOfTravel.x * speed * Time.deltaTime,
				directionOfTravel.y * speed * Time.deltaTime,
				directionOfTravel.z * speed * Time.deltaTime,
				Space.World
			);
		}
		else
		{

			// If the waypoint has a pause amount then wait a bit
			if (currentWaypoint.waitSeconds > 0)
			{
				Pause();
				Invoke("Pause", currentWaypoint.waitSeconds);
			}

			// If the current waypoint has a speed change then change to it
			if (currentWaypoint.speedOut > 0)
			{
				speedStorage = speed;
				speed = currentWaypoint.speedOut;
			}
			else if (speedStorage != 0)
			{
				speed = speedStorage;
				speedStorage = 0;
			}

			NextWaypoint();
		}

	}



	/**
	 * Work out what the next waypoint is going to be
	 * 
	 */
	private void NextWaypoint()
	{
		if (isCircular)
		{

			if (!inReverse)
			{
				currentIndex = (currentIndex + 1 >= wayPoints.Count) ? 0 : currentIndex + 1;
			}
			else
			{
				currentIndex = (currentIndex == 0) ? wayPoints.Count - 1 : currentIndex - 1;
			}

		}
		else
		{

			// If at the start or the end then reverse
			if ((!inReverse && currentIndex + 1 >= wayPoints.Count) || (inReverse && currentIndex == 0))
			{
				inReverse = !inReverse;
			}

			currentIndex = (!inReverse) ? currentIndex + 1 : currentIndex - 1;

		}

		currentWaypoint = wayPoints[currentIndex];
	}

	public void PlayerDetection()
	{
		currentPosition = this.transform.position;
		targetPosition = GameObject.FindWithTag("Player").transform.position;
		vectorToTarget = targetPosition - currentPosition;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Time.deltaTime * 1000f);
		speed = 0.6f;
		if (Vector3.Distance(currentPosition, targetPosition) > .1f)
		{

			// Get the direction and normalize
			directionOfTravel = targetPosition - currentPosition;
			directionOfTravel.Normalize();

			//scale the movement on each axis by the directionOfTravel vector components
			this.transform.Translate(
				directionOfTravel.x * speed * Time.deltaTime,
				directionOfTravel.y * speed * Time.deltaTime,
				directionOfTravel.z * speed * Time.deltaTime,
				Space.World
			);
		}
		if (!stillChasing) {
			StartCoroutine(ChaseTime(5f));
		}
	}
}