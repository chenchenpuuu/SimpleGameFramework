using UnityEngine;
using System.Collections;

public abstract class IView {

	public void Start () 
	{
		OnStart ();
	}

	public void Destroy()
	{
		OnDestroy ();
	}

	public void Show()
	{
		OnShow ();
	}

	public void Hide()
	{
		OnHide ();
	}

	public void Click(GameObject sender, object param)
	{
		OnClick (sender, param);
	}

	public void Press(GameObject sender, object param) //按住不放
	{
		OnPress (sender, param);
	}

	public void Drag(GameObject sender, object param)
	{
		OnDrag (sender, param);
	}

	protected abstract void OnStart();
	protected abstract void OnDestroy();
	protected abstract void OnShow();
	protected abstract void OnHide();
	protected abstract void OnClick(GameObject sender, object param);
	protected abstract void OnPress(GameObject sender, object param);
	protected abstract void OnDrag(GameObject sender, object param);
}
