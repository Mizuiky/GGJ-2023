using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndHealerDialog : EndDialogBase
{
    public override void EndCallBack()
    {
        base.EndCallBack();

        GameManager.Instance.InitializeItems();
    }
}
