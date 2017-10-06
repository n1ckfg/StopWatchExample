using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch {

	// https://forum.processing.org/one/topic/timer-in-processing.html

	public float startTime = 0f;
	public float stopTime = 0f;
	public bool running = false;   
	public float countdownMin = 0f;

	// If you create the class with a countdown argument other than zero, it counts down.
	public StopWatch(float _countdownMin) {
		init();
		countdownMin = _countdownMin;
	}

	public void init() {
		startTime = 0f;
		stopTime = 0f;
		running = false;  
	}

	public void start() {
		startTime = Time.realtimeSinceStartup;
		running = true;
	}

	public void stop() {
		stopTime = Time.realtimeSinceStartup;
		running = false;
	}

	public float getElapsedTime() {
		float elapsed;
		if (running) {
			elapsed = (Time.realtimeSinceStartup - startTime);
		} else {
			elapsed = (stopTime - startTime);
		}
		return elapsed;
	}

	public int second() {
		if (running) {
			float sec = (getElapsedTime() / 1f) % 60f;
			if (countdownMin == 0f) {
				return (int) sec;
			} else {
				float secDown = 59f - sec;
				if (secDown < 0f) {
					secDown = 0f;
				} else if (secDown > 59f) {
					secDown = 59f;
				}
				if (running && secDown == 0f && minute() == 0f) init();
				return (int) secDown;
			}
		} else {
			return 0;
		}
	}

	public int minute() {
		if (running) {
			float min = (getElapsedTime() / (1f*60f)) % 60f;
			if (countdownMin == 0f) {
				return (int) min; 
			} else {
				float minDown = (countdownMin - 1f) - min;
				if (minDown < 0f) {
					minDown = 0f;
				} else if (minDown > countdownMin) {
					minDown = countdownMin;
				}
				return (int) minDown;
			}
		} else {
			return 0;
		}
	}

	public int hour() {
		if (running) {
			float returns = (getElapsedTime() / (1f*60f*60f)) % 24f;
			return (int) returns;
		} else {
			return 0;
		}
	}

	public bool countdownFinished() {
		bool returns = countdownMin != 0f && minute() <= 0f && second() <= 0f;
		if (returns) init();
		return returns;
	}

}
