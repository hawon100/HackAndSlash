using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
	int _mask = (1 << (int)Define.Layer.None) | (1 << (int)Define.Layer.Block);

	Texture2D _handIcon;

	enum CursorType
	{
		None,
		Hand,
	}

	CursorType _cursorType = CursorType.None;

	void Awake()
    {
        _handIcon = Resources.Load<Texture2D>("Texture/Cursor/Hand");
    }

    void Update()
    {
		if (Input.GetMouseButton(0))
			return;

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		//Debug.DrawRay(Camera.main.transform.position, ray.direction * 100f, Color.red, 1f);

		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100.0f, _mask))
		{
			switch(hit.collider.gameObject.layer)
			{
                default:
                    if (_cursorType != CursorType.Hand)
                    {
                        Cursor.SetCursor(_handIcon, new Vector2(_handIcon.width / 4f, 0f), CursorMode.Auto);
                        _cursorType = CursorType.Hand;
                    }
                    break;
            }
		}
	}
}
