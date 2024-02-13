using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using System;

[RequireComponent(typeof(FirstPersonController))]
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

    [Space(15)]
    public Task[] task;
    [Space(15)]


    public LayerMask LayerMask;

    public Transform IneventoryPoint;
    public Transform ThrowOutPoint;

    public int indexActiveObject;
    public Image[] Image;

    public GameObject Buttons;

    public GameObject[] Frame;
    public GameObject[] Ineventory;

    [Space(10)]

    #region Second_Piano
    [Header("Second Piano")][Space(5)]
    public GameObject Key1;

    public bool piano;
    public Transform PianoCamera;

    public GameObject[] KeyPianoInput;
    public GameObject[] KeyPianoOutput;
    #endregion

    [Space(10)]

    #region Puddle
    [Header("Puddle")][Space(5)]
    public GameObject PuddleKey;
    public GameObject CapCap;
    #endregion

    [Space(10)]

    #region Letest
    [Header("Indices")][Space(5)]
    public GameObject[] Tools;
    public GameObject[] NeedTools;
    #endregion

    [Space(10)]

    #region Indices
    [Header("Indices")][Space(5)]
    int PianoI;
    int bolts;
    int puddleBolts;
    int index = 0;
    int closetdoors;
    #endregion

    Ray ray;
    Quaternion CameraRotation;


    void Awake()
    {
        if (lockCursor) LockCursor();
        else UnlockCursor();

        PuddleKey.SetActive(false);
        KeyPianoInput = new GameObject[KeyPianoOutput.Length];

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
    void Start()
    {

    }

    void Update()
    {
        //ThrowOut
        if (!piano && indexActiveObject < Ineventory.Length && indexActiveObject >= 0 && Input.GetKeyDown(throwOut) && Ineventory[0] != null && Ineventory[indexActiveObject] != null)
        {
            ThrowOut();
        }

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10f, LayerMask, QueryTriggerInteraction.Ignore))
        {
            //When piano
            if (piano)
            {
                //if(debug) print(hit.collider.gameObject.name);

                if (debug) Debug.DrawRay(Camera.main.gameObject.transform.position, Input.mousePosition, Color.blue);
                Camera.main.gameObject.transform.position = PianoCamera.position;

                if (Input.GetKeyDown(DrawRays) && hit.collider.gameObject.layer == 11 && PianoI < KeyPianoOutput.Length)
                {
                    KeyPianoInput[PianoI] = hit.collider.gameObject;
                    PianoI++;
                    if (debug) print(hit.collider.gameObject.name + "	" + "Input.GetKeyDown(DrawRays");
                    hit.collider.gameObject.GetComponent<Animator>().SetBool("Click", true);
                    hit.collider.gameObject.GetComponentInChildren<AudioSource>().Play();
                }
                else if (Input.GetKeyDown(DrawRays) && hit.collider.gameObject.layer == 11 && PianoI >= KeyPianoOutput.Length)
                {
                    PianoI = 0;
                    KeyPianoInput = new GameObject[KeyPianoOutput.Length];
                }
                if (Input.GetKeyDown(DrawRays) && hit.collider.gameObject.layer == 11 && hit.collider.gameObject.GetComponent<Key>() && hit.collider.gameObject.GetComponent<Key>().Delete)
                {
                    PianoI = 0;
                    KeyPianoInput = new GameObject[KeyPianoOutput.Length];
                }
            }

			//Add object in inventary
			if (Input.GetKeyDown(DrawRays) && hit.collider.gameObject.tag == "Interact" && hit.collider.gameObject.GetComponent<Key>())
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
                    for(int i = 0; i < Tools.Length; i++)
                    {
                        if (Ineventory[index] == Tools[i]) Tools[i] = null;
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
            //Use object from inventary
            if (indexActiveObject < Ineventory.Length && indexActiveObject >= 0 && Ineventory[indexActiveObject] != null && Input.GetKeyDown(Interact) && hit.collider.gameObject.layer == Ineventory[indexActiveObject].layer && Ineventory[0] != null)
			{
                //Open closet1
                if (Ineventory[indexActiveObject].layer == 12 && Ineventory[indexActiveObject] != hit.collider.gameObject)
                {
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    hit.collider.gameObject.GetComponentInChildren<AudioSource>().Play();
                    closetdoors++;

                    if (closetdoors >= 2 && Ineventory[indexActiveObject] != hit.collider.gameObject && Ineventory[indexActiveObject].layer == 12)
					{
                        GameObject Obj = Ineventory[indexActiveObject];
						IfDestroy();
                        //Destroy(Obj);
                        print(Obj);
                        Obj.SetActive(false);
					}
                }
                //Open closet2
                if (Ineventory[indexActiveObject] != null && Ineventory[indexActiveObject].layer == 13 && Ineventory[indexActiveObject] != hit.collider.gameObject)
                {
                    Destroy(hit.collider.gameObject.GetComponent<MeshFilter>());
                    Destroy(hit.collider.gameObject.GetComponent<MeshRenderer>());
                    Destroy(hit.collider.gameObject.GetComponent<MeshCollider>());
                    hit.collider.gameObject.GetComponentInChildren<AudioSource>().Play();
                }
				//Bolts
                if (Ineventory[indexActiveObject] != null && Ineventory[indexActiveObject].layer == 14 && Ineventory[indexActiveObject] != hit.collider.gameObject)
                {
					Destroy(hit.collider.gameObject.GetComponent<MeshCollider>());
                    hit.collider.gameObject.transform.GetChild(0).gameObject.SetActive(false);
                    puddleBolts++;
					if (puddleBolts >= 2)
					{
						GameObject.FindGameObjectWithTag("Puddle").SetActive(false);
						PuddleKey.SetActive(true);
                        CapCap.SetActive(false);

                    }
                }
                //Delete bolts
                if (Ineventory[indexActiveObject] != null && Ineventory[indexActiveObject].layer == 9 && hit.collider.gameObject != Ineventory[indexActiveObject])
				{
					bolts++;
					Destroy(hit.collider.gameObject.transform.parent.gameObject);
					if (bolts >= 4) Destroy(hit.collider.gameObject.transform.parent.parent.gameObject);
				}
                //Open door1
                if (Ineventory[indexActiveObject] != null && Ineventory[indexActiveObject].layer == 7 && Ineventory[indexActiveObject] != hit.collider.gameObject)
                {
                    Ineventory[indexActiveObject].SetActive(false);
                    //hit.collider.gameObject.transform.parent.parent.gameObject.GetComponent<Animator>().enabled = true;
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    Ineventory[indexActiveObject] = null;
                    IfDestroy();
                }
                //Open door2
                if (Ineventory[indexActiveObject] != null && Ineventory[indexActiveObject].layer == 8 && Ineventory[indexActiveObject] != hit.collider.gameObject)
                {
                    Ineventory[indexActiveObject].SetActive(false);
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                    hit.collider.gameObject.GetComponent<PlayableDirector>().enabled = true;
                    GetComponent<Animator>().enabled = true;
                    Ineventory[indexActiveObject] = null;
                    IfDestroy();
                }
                //Open Siutcase
                if (Ineventory[indexActiveObject] != null && Ineventory[indexActiveObject].layer == 15 && Ineventory[indexActiveObject] != hit.collider.gameObject)
                {
                    Ineventory[indexActiveObject].SetActive(false);
                    hit.collider.gameObject.transform.parent.gameObject.GetComponent<Animator>().enabled = true;
					IfDestroy();
                }
				//Put notes
                if (Ineventory[indexActiveObject] != null && Ineventory[indexActiveObject].layer == 17 && Ineventory[indexActiveObject] != hit.collider.gameObject)
                {
                    Ineventory[indexActiveObject].transform.position = hit.collider.gameObject.transform.position;
                    Ineventory[indexActiveObject].transform.rotation = hit.collider.gameObject.transform.rotation;
                    Ineventory[indexActiveObject].transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    IfDestroy();
                }
                //Open WinBox
                if (Ineventory[indexActiveObject] != null && Ineventory[indexActiveObject].layer == 19 && Ineventory[indexActiveObject] != hit.collider.gameObject)
                {
                    hit.collider.gameObject.GetComponent<Animator>().enabled = true;
                }
            }

            //Tools in toolbox
            if (indexActiveObject < Ineventory.Length && indexActiveObject >= 0 && Ineventory[indexActiveObject] != null && hit.collider.gameObject.GetComponent<Key>() && hit.collider.gameObject.GetComponent<Key>().LatestLevel && Ineventory[indexActiveObject] != hit.collider.gameObject && Input.GetKeyDown(Interact) && Ineventory[0] != null && Tools[hit.collider.gameObject.GetComponent<Key>().index] == null)
            {
				Tools[hit.collider.gameObject.GetComponent<Key>().index] = Ineventory[indexActiveObject];
                int indexActive = 0;
				#region IfDel
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

                Image[indexActive].sprite = null;

                Ineventory[indexActive].transform.parent = null;
                Ineventory[indexActive].GetComponent<Collider>().enabled = true;


                Ineventory[indexActive] = null;
                for (int i = indexActive; i < Ineventory.Length - 1; i++)
                {
                    if (i < Ineventory.Length - 1 && Ineventory[i] == null)
                    {
                        Ineventory[i] = Ineventory[i + 1];
                        Ineventory[i + 1] = null;
                    }
                }
                #endregion
                NotActive();
                if(Tools[hit.collider.gameObject.GetComponent<Key>().index].layer == 9 || Tools[hit.collider.gameObject.GetComponent<Key>().index].layer == 13)
                {
                    Ineventory[indexActive].transform.position = hit.collider.gameObject.transform.position;
                    Ineventory[indexActive].transform.rotation = hit.collider.gameObject.transform.rotation;  
                }
                else if (Tools[hit.collider.gameObject.GetComponent<Key>().index].layer == 14)
                {
                    Ineventory[indexActive].transform.position = hit.collider.gameObject.transform.position;
                    Ineventory[indexActive].transform.rotation = hit.collider.gameObject.transform.rotation;
                }
                else if (Tools[hit.collider.gameObject.GetComponent<Key>().index].layer == 16)
                {
                    Ineventory[indexActive].transform.position = hit.collider.gameObject.transform.position;
                    Ineventory[indexActive].transform.rotation = hit.collider.gameObject.transform.rotation;
                }

            }

            //Open Toolbox
            if (hit.collider.gameObject.tag == "Toolbox" && Input.GetKeyDown(Interact))
			{
				hit.collider.gameObject.transform.parent.gameObject.GetComponent<Animator>().enabled = true;
			}
			//Start piano
			if (Input.GetKeyDown(Interact) && hit.collider.gameObject.layer == 10 && piano == false || Input.GetKeyDown(Interact) && hit.collider.gameObject.layer == 11 && piano == false)
			{
				piano = true;
				CameraRotation = Camera.main.gameObject.transform.rotation;
				Camera.main.gameObject.transform.rotation = PianoCamera.rotation;
				Camera.main.gameObject.transform.parent.parent.transform.gameObject.GetComponent<FirstPersonController>().enabled = false;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
			}
			//Over piano
			if (Input.GetKeyDown(throwOut) && piano)
			{
				piano = false;
				Camera.main.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				Camera.main.gameObject.transform.rotation = CameraRotation;
				Camera.main.gameObject.transform.parent.parent.transform.gameObject.GetComponent<FirstPersonController>().enabled = true;
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
			}
        }

        //Piano key input == key output ?
        int pianoIndex = 0;
        if (Key1 != null && KeyPianoInput[KeyPianoInput.Length - 1] != null && !Key1.activeSelf)
        {
            for (int i = 0; i < KeyPianoOutput.Length; i++)
            {
                if (KeyPianoInput[i] == KeyPianoOutput[i])
                {
					pianoIndex++;
                }
            }
        }
        if(pianoIndex == KeyPianoInput.Length)
        {
            Key1.SetActive(true);
            piano = false;
            Camera.main.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
            Camera.main.gameObject.transform.rotation = CameraRotation;
            Camera.main.gameObject.transform.parent.parent.transform.gameObject.GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (KeyPianoInput == KeyPianoOutput) print("Yes");

        //Tools[0] != null;
        int toolIndex = 0;
        if (Tools[0] != null && Tools[NeedTools.Length - 1] != null)
        {
            for (int i = 0; i < NeedTools.Length; i++)
            {
                if (Tools[i] == NeedTools[i])
                {
					toolIndex++;
                }
            }
        }
        if (toolIndex >= NeedTools.Length) GameObject.FindGameObjectWithTag("Toolbox").gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("Win", true);
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
            //Notes Scale
            if (Ineventory[indexActiveObject].layer == 17)
            {
                Ineventory[indexActiveObject].transform.localScale = new Vector3(1f, 1f, 1f);
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
[System.Serializable]
public struct Task
{
    public string fieldTypeAnswer;
    [InspectorName("Maximum points"), Tooltip("")]
    public TaskType type;

    [HideInInspector] public GameObject TaskObj;

    [HideInInspector] public GameObject _buttonNext;
    [HideInInspector] public GameObject _buttonPreviuos;

    [HideInInspector] public GameObject Answers_Toggle;
    [HideInInspector] public GameObject Answers_InputField;
}
[System.Serializable]
public enum TaskType
{
    [InspectorName("None")] none,
}