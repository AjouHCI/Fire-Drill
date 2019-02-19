using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointTrack : MonoBehaviour {

	public Color lineColor = Color.yellow;
	private Transform[] points;

	void OnDrawGizmos(){
		Gizmos.color = lineColor;
		points = GetComponentsInChildren<Transform>();

		int nextIdx = 1;

		Vector3 currPos = points[nextIdx].position;
		Vector3 nextPos;

		for(int i = 0; i <= points.Length; i++){
			nextPos = (++nextIdx >= points.Length) ? points[1].position : points[nextIdx].position;
			Gizmos.DrawLine(currPos, nextPos);
			currPos = nextPos;
		}

	}
}
