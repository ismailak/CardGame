using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardGame.EventBusSystem
{
    public static class GlobalBus
    {
        public static readonly EventBus Sync = new EventBus();
    }
}