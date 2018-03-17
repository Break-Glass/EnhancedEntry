﻿using Xamarin.Forms;

namespace LeoJHarris.EnhancedEntry.Plugin.Abstractions.Portable.Effects
{
    public class ShowHiddenEntryEffect : RoutingEffect
    {
        public string EntryText { get; set; }
        public ShowHiddenEntryEffect() : base("Xamarin.ShowHiddenEntryEffect") { }
    }
}
