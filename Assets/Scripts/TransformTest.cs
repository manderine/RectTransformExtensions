using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TransformTest : MonoBehaviour {
	public Vector3 _size = Vector3.zero;
	public Vector3 _position = Vector3.zero;
	public AnchorPresets _anchor = AnchorPresets.None;
	public PivotPresets _pivot = PivotPresets.None;

	private void LateUpdate() {
		transform.GetComponent<RectTransform>().SetAnchor( _anchor );
		transform.GetComponent<RectTransform>().SetSize( _size.x, _size.y );
		transform.GetComponent<RectTransform>().SetPosition( _position.x, _position.y );
		transform.GetComponent<RectTransform>().SetPivot( _pivot );
	}
}
