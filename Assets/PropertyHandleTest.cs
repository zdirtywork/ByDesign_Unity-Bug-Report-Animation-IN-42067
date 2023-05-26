using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

// About this issue:
// The property of a component becomes read-only after it is bound to a `PropertyStreamHandle`.
// 
// How to reproduce:
// 1. Open the "SampleScene".
// 2. Enter Play Mode.
// 3. Select the "Player" object in the Hierarchy.
// 4. Try to change the value of the "Value" property in the "Property Handle Test (Script)" component.
// Expected result: The value of the "Value" property can be changed.
// Actual result: The value of the "Value" property cannot be changed.

[RequireComponent(typeof(Animator))]
public class PropertyHandleTest : MonoBehaviour
{
    [Range(0f, 1f)]
    public float value;

    private PlayableGraph _graph;

    private void Start()
    {
        var animator = GetComponent<Animator>();
        animator.BindStreamProperty(transform, GetType(), nameof(value));

        _graph = PlayableGraph.Create("PropertyHandleDemo");

        var acp = AnimationClipPlayable.Create(_graph, null);
        var output = AnimationPlayableOutput.Create(_graph, "Animation", animator);
        output.SetSourcePlayable(acp);

        _graph.Play();
    }

    private void OnDestroy()
    {
        if (_graph.IsValid()) _graph.Destroy();
    }
}
