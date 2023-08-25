﻿// Attach to the prefab for easier component access by the UI Scripts.
// Otherwise we would need slot.GetChild(0).GetComponentInChildren<Text> etc.
using UnityEngine;
using UnityEngine.UI;

namespace uSurvival
{
    public class UIEquipmentSlot : MonoBehaviour
    {
        public UIShowToolTip tooltip;
        public UIDragAndDropable dragAndDropable;
        public Image image;
        public GameObject categoryOverlay;
        public Text categoryText;
        public Image cooldownCircle;
        public GameObject amountOverlay;
        public Text amountText;
    }
}