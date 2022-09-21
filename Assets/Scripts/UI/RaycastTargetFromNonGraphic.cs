using UnityEngine.UI;

public class RaycastTargetFromNonGraphic : Graphic
{
    public override void SetMaterialDirty() { return; }
    public override void SetVerticesDirty() { return; }
}
