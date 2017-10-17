using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public enum AnchorPresets {
	None = 0,

	TopLeft,
	TopCenter,
	TopRight,
 
	MiddleLeft,
	MiddleCenter,
	MiddleRight,
 
	BottomLeft,
	BottonCenter,
	BottomRight,
 
	HorStretchTop,
	HorStretchMiddle,
	HorStretchBottom,

	VertStretchLeft,
	VertStretchCenter,
	VertStretchRight,
 
	StretchAll
}

public enum PivotPresets {
	None = 0,

	TopLeft,
	TopCenter,
	TopRight,
 
	MiddleLeft,
	MiddleCenter,
	MiddleRight,
 
	BottomLeft,
	BottomCenter,
	BottomRight
}

public static class RectTransformExtensions {
	static Dictionary<AnchorPresets, Vector4> __dic_anchor_1 = new Dictionary<AnchorPresets, Vector4> {
		{ AnchorPresets.TopLeft,			new Vector4(0f,1f,0f,1f) },
		{ AnchorPresets.TopCenter,			new Vector4(0.5f,1f,0.5f,1f) },
		{ AnchorPresets.TopRight,			new Vector4(1f,1f,1f,1f) },

		{ AnchorPresets.MiddleLeft,			new Vector4(0f,0.5f,0f,0.5f) },
		{ AnchorPresets.MiddleCenter,		new Vector4(0.5f,0.5f,0.5f,0.5f) },
		{ AnchorPresets.MiddleRight,		new Vector4(1f,0.5f,1f,0.5f) },

		{ AnchorPresets.BottomLeft,			new Vector4(0f,0f,0f,0f) },
		{ AnchorPresets.BottonCenter,		new Vector4(0.5f,0f,0.5f,0f) },
		{ AnchorPresets.BottomRight,		new Vector4(1f,0f,1f,0f) },

		{ AnchorPresets.HorStretchTop,		new Vector4(0f,1f,1f,1f) },
		{ AnchorPresets.HorStretchMiddle,	new Vector4(0f,0.5f,1f,0.5f) },
		{ AnchorPresets.HorStretchBottom,	new Vector4(0f,0f,1f,0f) },

		{ AnchorPresets.VertStretchLeft,	new Vector4(0f,0f,0f,1f) },
		{ AnchorPresets.VertStretchCenter,	new Vector4(0.5f,0f,0.5f,1f) },
		{ AnchorPresets.VertStretchRight,	new Vector4(1f,0f,1f,1f) },

		{ AnchorPresets.StretchAll,			new Vector4(0f,0f,1f,1f) }
	};

	static Dictionary<Vector4, AnchorPresets> __dic_anchor_2 = null;

	static Dictionary<PivotPresets, Vector2> __dic_pivot_1 = new Dictionary<PivotPresets, Vector2> {
		{ PivotPresets.TopLeft,				new Vector2(0f,1f) },
		{ PivotPresets.TopCenter,			new Vector2(0.5f,1f) },
		{ PivotPresets.TopRight,			new Vector2(1f,1f) },

		{ PivotPresets.MiddleLeft,			new Vector2(0f,0.5f) },
		{ PivotPresets.MiddleCenter,		new Vector2(0.5f,0.5f) },
		{ PivotPresets.MiddleRight,			new Vector2(1f,0.5f) },

		{ PivotPresets.BottomLeft,			new Vector2(0f,0f) },
		{ PivotPresets.BottomCenter,		new Vector2(0.5f,0f) },
		{ PivotPresets.BottomRight,			new Vector2(1f,0f) }
	};

	static Dictionary<Vector2, PivotPresets> __dic_pivot_2 = null;

	public static bool SetAnchor( this RectTransform source, AnchorPresets allign ) {
		if( __dic_anchor_1.ContainsKey( allign ) == true ) {
			Vector4 v4 = __dic_anchor_1[ allign ];

			source.anchorMin = new Vector2(v4.x, v4.y);
			source.anchorMax = new Vector2(v4.z, v4.w);
			return true;
		}
		return false;
	}

	public static AnchorPresets GetAnchor( this RectTransform source ) {
		if( __dic_anchor_2 == null ) {
			__dic_anchor_2 = new Dictionary<Vector4, AnchorPresets>();
			foreach( KeyValuePair<AnchorPresets, Vector4> each in __dic_anchor_1 ) {
				if( __dic_anchor_2.ContainsKey( each.Value ) == false ) {
					__dic_anchor_2.Add( each.Value, each.Key );
				}
			}
		}

		Vector4 v4 = new Vector4( source.anchorMin.x, source.anchorMin.y, source.anchorMax.x, source.anchorMax.y );
		if( __dic_anchor_2.ContainsKey( v4 ) == true ) {
			return __dic_anchor_2[ v4 ];
		}

		return AnchorPresets.None;
	}
 
	public static bool SetPivot( this RectTransform source, PivotPresets preset ) {
		if( __dic_pivot_1.ContainsKey( preset ) == true ) {
			Vector2 v2= __dic_pivot_1[ preset ];

			source.pivot = new Vector2(v2.x, v2.y);
			return true;
		}
		return false;
	}

	public static PivotPresets GetPivot( this RectTransform source ) {
		if( __dic_pivot_2 == null ) {
			__dic_pivot_2 = new Dictionary<Vector2, PivotPresets>();
			foreach( KeyValuePair<PivotPresets, Vector2> each in __dic_pivot_1 ) {
				if( __dic_pivot_2.ContainsKey( each.Value ) == false ) {
					__dic_pivot_2.Add( each.Value, each.Key );
				}
			}
		}

		Vector2 v2 = new Vector2( source.pivot.x, source.pivot.y );
		if( __dic_pivot_2.ContainsKey( v2 ) == true ) {
			return __dic_pivot_2[ v2 ];
		}

		return PivotPresets.None;
	}

	public static void SetPosition( this RectTransform source, float offsetx, float offsety ) {
		AnchorPresets allign = GetAnchor( source );
		switch( allign ) {
		case AnchorPresets.TopLeft :
		case AnchorPresets.TopCenter :
		case AnchorPresets.TopRight :
		case AnchorPresets.MiddleLeft :
		case AnchorPresets.MiddleCenter :
		case AnchorPresets.MiddleRight :
		case AnchorPresets.BottomLeft :
		case AnchorPresets.BottonCenter :
		case AnchorPresets.BottomRight :
			source.anchoredPosition = new Vector3(offsetx, offsety, 0f);
			break;
		case AnchorPresets.HorStretchTop :
		case AnchorPresets.HorStretchMiddle :
		case AnchorPresets.HorStretchBottom :
			source.anchoredPosition = new Vector3(offsetx, -offsety, 0f);
			break;
		case AnchorPresets.VertStretchLeft :
		case AnchorPresets.VertStretchCenter :
		case AnchorPresets.VertStretchRight :
			source.anchoredPosition = new Vector3(offsetx, offsety, 0f);
			break;
		case AnchorPresets.StretchAll :
			source.anchoredPosition = new Vector3(offsetx, -offsety, 0f);
			break;
		}
	}

	public static Vector2 GetPosition( this RectTransform source ) {
		AnchorPresets allign = GetAnchor( source );
		switch( allign ) {
		case AnchorPresets.TopLeft :
		case AnchorPresets.TopCenter :
		case AnchorPresets.TopRight :
		case AnchorPresets.MiddleLeft :
		case AnchorPresets.MiddleCenter :
		case AnchorPresets.MiddleRight :
		case AnchorPresets.BottomLeft :
		case AnchorPresets.BottonCenter :
		case AnchorPresets.BottomRight :
			break;
		case AnchorPresets.HorStretchTop :
		case AnchorPresets.HorStretchMiddle :
		case AnchorPresets.HorStretchBottom :
			return new Vector2( source.anchoredPosition.x, -source.anchoredPosition.y );
		case AnchorPresets.VertStretchLeft :
		case AnchorPresets.VertStretchCenter :
		case AnchorPresets.VertStretchRight :
			break;
		case AnchorPresets.StretchAll :
			return new Vector2( source.anchoredPosition.x, -source.anchoredPosition.y );
		}
		return source.anchoredPosition;
	}

	public static void SetSize( this RectTransform source, float width, float height ) {
		AnchorPresets allign = GetAnchor( source );
		switch( allign ) {
		case AnchorPresets.TopLeft :
		case AnchorPresets.TopCenter :
		case AnchorPresets.TopRight :
		case AnchorPresets.MiddleLeft :
		case AnchorPresets.MiddleCenter :
		case AnchorPresets.MiddleRight :
		case AnchorPresets.BottomLeft :
		case AnchorPresets.BottonCenter :
		case AnchorPresets.BottomRight :
			source.sizeDelta = new Vector2( width, height );
			break;
		case AnchorPresets.HorStretchTop :
		case AnchorPresets.HorStretchMiddle :
		case AnchorPresets.HorStretchBottom :
			{
				RectTransform parent = source.parent.GetComponent<RectTransform>();
				Vector2 size = parent.GetSize();
				source.sizeDelta = new Vector2( width - size.x, height );
			}
			break;
		case AnchorPresets.VertStretchLeft :
		case AnchorPresets.VertStretchCenter :
		case AnchorPresets.VertStretchRight :
			{
				RectTransform parent = source.parent.GetComponent<RectTransform>();
				Vector2 size = parent.GetSize();
				source.sizeDelta = new Vector2( width, height - size.y );
			}
			break;
		case AnchorPresets.StretchAll :
			{
				RectTransform parent = source.parent.GetComponent<RectTransform>();
				Vector2 size = parent.GetSize();
				source.sizeDelta = new Vector2( width - size.x, height - size.y );
			}
			break;
		}
	}

	public static void SetSize( this RectTransform source ) {
		RectTransform parent = source.parent.GetComponent<RectTransform>();
		Vector2 size = parent.GetSize();
		source.SetSize( size.x, size.y );
	}

	public static Vector2 GetSize( this RectTransform source ) {
		CanvasScaler scaler = source.GetComponent<CanvasScaler>();
		if( scaler != null ) {
			switch( scaler.uiScaleMode ) {
			case CanvasScaler.ScaleMode.ScaleWithScreenSize:
				switch( scaler.screenMatchMode ) {
				case CanvasScaler.ScreenMatchMode.MatchWidthOrHeight:
					{
						float width = scaler.referenceResolution.y * Screen.width / Screen.height;
						width = scaler.referenceResolution.x + (width - scaler.referenceResolution.x) * scaler.matchWidthOrHeight;
						float height = width * Screen.height / Screen.width;
						return new Vector2( Mathf.RoundToInt( width ), Mathf.RoundToInt( height ) );
					}
				case CanvasScaler.ScreenMatchMode.Expand: // height fix
					{
						float width = scaler.referenceResolution.y * Screen.width / Screen.height;
						return new Vector2( Mathf.RoundToInt( width ), Mathf.RoundToInt( scaler.referenceResolution.y ) );
					}
				case CanvasScaler.ScreenMatchMode.Shrink: // width fix
					{
						float height = scaler.referenceResolution.x * Screen.height / Screen.width;
						return new Vector2( Mathf.RoundToInt( scaler.referenceResolution.x ), Mathf.RoundToInt( height ) );
					}
				}
				break;
			}
		}

		AnchorPresets allign = GetAnchor( source );
		switch( allign ) {
		case AnchorPresets.TopLeft :
		case AnchorPresets.TopCenter :
		case AnchorPresets.TopRight :
		case AnchorPresets.MiddleLeft :
		case AnchorPresets.MiddleCenter :
		case AnchorPresets.MiddleRight :
		case AnchorPresets.BottomLeft :
		case AnchorPresets.BottonCenter :
		case AnchorPresets.BottomRight :
			return source.sizeDelta;
		case AnchorPresets.HorStretchTop :
		case AnchorPresets.HorStretchMiddle :
		case AnchorPresets.HorStretchBottom :
			{
				RectTransform parent = source.parent.GetComponent<RectTransform>();
				Vector2 size = parent.GetSize();
				return new Vector2( source.sizeDelta.x, size.y + source.sizeDelta.y );
			}
		case AnchorPresets.VertStretchLeft :
		case AnchorPresets.VertStretchCenter :
		case AnchorPresets.VertStretchRight :
			{
				RectTransform parent = source.parent.GetComponent<RectTransform>();
				Vector2 size = parent.GetSize();
				return new Vector2( size.x + source.sizeDelta.x, source.sizeDelta.y );
			}
		case AnchorPresets.StretchAll :
			{
				RectTransform parent = source.parent.GetComponent<RectTransform>();
				return (parent.GetSize() + source.sizeDelta);
			}
		}
		return Vector2.zero;
	}
}
