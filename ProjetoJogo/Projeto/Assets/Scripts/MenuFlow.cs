using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class MenuFlow : MonoBehaviour
{
    public bool enterSubmit;
    [SerializeField]
    public Button submit;
    public List<TMP_InputField> inputInOrder;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            for (int i = 0; i < inputInOrder.Count; i++)
            {
                if (inputInOrder[i].isFocused)
                {
                    if (inputInOrder.Count - 1 == i)
                    {
                        inputInOrder[0].Select();
                    }
                    else
                    {
                        inputInOrder[i + 1].Select();
                    }

                }
            }
        }
        if (enterSubmit && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            submit.onClick.Invoke();
        }

    }
}
