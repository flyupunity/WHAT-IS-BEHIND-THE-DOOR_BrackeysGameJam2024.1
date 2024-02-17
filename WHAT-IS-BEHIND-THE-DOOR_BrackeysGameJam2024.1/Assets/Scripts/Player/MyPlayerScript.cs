using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using System;
using TMPro;

public class MyPlayerScript : MonoBehaviour
{
    public bool debug;
    public bool programmer;
    public bool lockCursor;

    [Space(10)]

    #region InputKey
    [Header("Input Keys")][Space(5)]
    public KeyCode Interact;
    public KeyCode throwOut;
    public KeyCode DrawRays;
    #endregion

    public LayerMask LayerMask;

    public Transform IneventoryPoint;
    public Transform ThrowOutPoint;

    public int indexActiveObject;

    public GameObject[] Ineventory;

    [Space(10)]

    #region Indices
    [Header("Indices")][Space(5)]
    int index = 0;

	#endregion
	#region UI
	[Header("User Interface")][Space(5)]
    public GameObject Buttons;
    public GameObject[] Frame;

    public Image[] Image;
    [SerializeField] private TextMeshProUGUI hoverTMPro = null;
    #endregion

    Ray ray;
    Quaternion CameraRotation;


    void Awake()
    {
        if (lockCursor) LockCursor();
        else UnlockCursor();

        GameObject[] Ignore = GameObject.FindGameObjectsWithTag("Interact");
        for (int i = 0; i < Ignore.Length; i++) 
        {
            if (Ignore[i].GetComponent<Collider>()) Physics.IgnoreCollision(Ignore[i].GetComponent<Collider>(), GetComponent<Collider>());
                if (programmer)
                {
                    Ignore[i].SetActive(true);
                    Ignore[i].transform.position = transform.position;
                }
        }
    }
    void Update()
    {
		hoverTMPro.text = "";
        //ThrowOut
        if (indexActiveObject < Ineventory.Length && indexActiveObject >= 0 && Input.GetKeyDown(throwOut) && Ineventory[0] != null && Ineventory[indexActiveObject] != null)
        {
            ThrowOut();
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f, LayerMask, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.gameObject.GetComponent<Key>())
			{
				hoverTMPro.text = hit.collider.gameObject.GetComponent<Key>().hoverText;
            }
            if (Input.GetKeyDown(DrawRays) && hit.collider.gameObject.GetComponent<DoorScript>())
			{
				hit.collider.gameObject.GetComponent<DoorScript>().OpenTheDoor();

            }

            //Add object in inventary
            if (Input.GetKeyDown(DrawRays) && hit.collider.gameObject.tag == "Interacting" && hit.collider.gameObject.GetComponent<Key>() && hit.collider.gameObject.GetComponent<Key>().dontTouch == false)
			{
				if (index < Ineventory.Length)
				{
					Ineventory[index] = hit.collider.gameObject;
					Ineventory[index].transform.position = IneventoryPoint.position;
					Ineventory[index].transform.rotation = IneventoryPoint.rotation;
					Ineventory[index].transform.parent = IneventoryPoint;
					Ineventory[index].GetComponent<Collider>().enabled = false;
					Image[index].sprite = Ineventory[index].GetComponent<Key>().Sprite;
					if (Ineventory[index].GetComponent<Rigidbody>())
					{
						Destroy(Ineventory[index].GetComponent<Rigidbody>());
					}
					index++;
					NotActive();
				}
				if (indexActiveObject < Ineventory.Length - 1 && Ineventory[indexActiveObject + 1] != null)
				{
					indexActiveObject++;
					NotActive();
				}
			}
        }
        //Active object
        if (Ineventory[0] != null && indexActiveObject < Ineventory.Length && indexActiveObject >= 0 && Ineventory[indexActiveObject] != null)
		{
			Ineventory[indexActiveObject].SetActive(true);
			Ineventory[indexActiveObject].transform.position = IneventoryPoint.position;
			Ineventory[indexActiveObject].transform.rotation = IneventoryPoint.rotation;
			Ineventory[indexActiveObject].transform.parent = IneventoryPoint;
			Ineventory[indexActiveObject].GetComponent<Collider>().enabled = false;

			NotActive();
			if (Ineventory[indexActiveObject].GetComponent<Rigidbody>())
			{
				Destroy(Ineventory[indexActiveObject].GetComponent<Rigidbody>());
			}
        }
    }
    public void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void IfDestroy()
	{
		int indexActive = 0;

		if (indexActiveObject > 0)
		{
			indexActive = indexActiveObject;
			indexActiveObject -= 1;
		}
		else if (indexActiveObject < 0)
		{
				indexActive = 0;
		}
		if (index > 0)
		{
			index -= 1;
		}


        Ineventory[indexActive].transform.parent = null;
        Ineventory[indexActive] = null;

        for (int i = indexActive; i < Ineventory.Length - 1; i++)
		{
			if (i < Ineventory.Length - 1 && Ineventory[i] == null)
			{
				Ineventory[i] = Ineventory[i + 1];
				Ineventory[i + 1] = null;
			}
		}
		NotActive();
	}

	public void ThrowOut()
	{
		int indexActive = 0;

		if (indexActiveObject > 0)
		{
			indexActive = indexActiveObject;
			indexActiveObject -= 1;
		}
		else if (indexActiveObject < 0)
		{
			indexActive = 0;
		}
		if (index > 0)
		{
			index -= 1;
		}
        //Notes Scale
        if (Ineventory[indexActive].layer == 17)
        {
            Ineventory[indexActive].transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
        }

        Image[indexActive].sprite = null;

		Ineventory[indexActive].transform.position = ThrowOutPoint.position;
		Ineventory[indexActive].transform.rotation = ThrowOutPoint.rotation;

		Ineventory[indexActive].transform.parent = null;
		Ineventory[indexActive].GetComponent<Collider>().enabled = true;
		if (!Ineventory[indexActive].GetComponent<Rigidbody>())
		{
			Ineventory[indexActive].AddComponent<Rigidbody>();
		}

		Ineventory[indexActive] = null;
		for (int i = indexActive; i < Ineventory.Length - 1; i++)
		{
			if (i < Ineventory.Length - 1 && Ineventory[i] == null)
			{
				Ineventory[i] = Ineventory[i + 1];
				Ineventory[i + 1] = null;
			}
		}
		NotActive();

	}
	public void OnEnableButtons()
	{
		Buttons.SetActive(!Buttons.activeSelf);
	}

	public void NotActive()
	{


		for (int i = 0; i < index; i++)
		{
			if (i != indexActiveObject && Ineventory[i] != null && Ineventory[i].layer != 6)
			{
				Ineventory[i].SetActive(false);

			}else if (i == indexActiveObject && Ineventory[i] != null)
			{
				Ineventory[i].SetActive(true);

			}
		}
		for (int i = 0; i < Ineventory.Length; i++)
		{
			if (i != indexActiveObject && Frame[i] != null) Frame[i].SetActive(false);
			else if (i == indexActiveObject && Frame[i] != null) Frame[i].SetActive(true);

            if (Image[i].sprite != null) Image[i].gameObject.SetActive(true);
            else if (Image[i].sprite == null) Image[i].gameObject.SetActive(false);

			if(Ineventory[i] != null) Image[i].sprite = Ineventory[i].GetComponent<Key>().Sprite;
			if(Ineventory[i] == null) 
			{
				Image[i].gameObject.SetActive(false);
				Image[i].sprite = null;
			}
        }
    }

	public void ButtonClick(int i)
	{
		if(Ineventory[i] != null) indexActiveObject = i;
	}
	public void OnUp()
	{
		if (indexActiveObject < index - 1)
		{
			indexActiveObject++;
			NotActive();
		}
	}
	public void OnDown()
	{
		if (indexActiveObject > 0) 
		{
			indexActiveObject--;
			NotActive();
		}
	}
}
