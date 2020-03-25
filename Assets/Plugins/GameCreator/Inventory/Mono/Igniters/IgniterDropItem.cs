﻿namespace GameCreator.Inventory
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using UnityEngine.EventSystems;
    using GameCreator.Core;

	[AddComponentMenu("")]
	public class IgniterDropItem : Igniter 
	{
		#if UNITY_EDITOR
		public new static string NAME = "Inventory/On Drop Item";
		public new static bool REQUIRES_COLLIDER = true;
        public new static string ICON_PATH = "Assets/Plugins/GameCreator/Inventory/Icons/Igniters/";
        public const string CUSTOM_ICON_PATH = "Assets/Plugins/GameCreator/Inventory/Icons/Igniters/";
        #endif

        public ItemHolder item;

        public void OnDrop(Item item)
        {
            if (item != null && item.uuid == this.item.item.uuid) this.ExecuteTrigger();
        }
	}
}