using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatchExample : MonoBehaviour {

	StopWatch stopWatch;
	public TextMesh textMesh;

	void Start() {
		stopWatch = new StopWatch(3f);
		stopWatch.start();
	}
	
	void Update() {
		textMesh.text = stopWatch.minute() + " : " + stopWatch.second();
	}

}
