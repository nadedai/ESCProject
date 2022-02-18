using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
namespace MultiReactive {
    public class MultiFeature : Feature {
        public MultiFeature(Contexts contexts) {
            Add(new MultiDestorySystem(contexts));
        }
    }
}

