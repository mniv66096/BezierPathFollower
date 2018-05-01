using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour {
    public BezierCurve Path;

    public void StartFollowingPath (float percentInSecond) {
        StartCoroutine(FollowPath(percentInSecond));
    }

    private IEnumerator FollowPath (float percentInSecond) {
        float percentage = 0.0f;
        while (percentage < 1.0f) {
            percentage += Time.deltaTime * percentInSecond;
            percentage = Mathf.Clamp(percentage, 0.0f, 1.0f);
            Vector3 point = Path.GetPointAt(percentage);
            point.y = transform.position.y;
            transform.forward = point - transform.position;
            transform.position = point;
            yield return null;  
        }
    }
}
