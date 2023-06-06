# Unity-Bug-Report-Animation-IN-42067

**Unity has stated that this was intentional by design.**

> RESOLUTION NOTE:
> Since animation writes back at every frame, it's expected that you won't be able to change the value.

## About this issue

The property of a component becomes read-only after it is bound to a `PropertyStreamHandle`.

## How to reproduce:

1. Open the "SampleScene".
2. Enter Play Mode.
3. Select the "Player" object in the Hierarchy.
4. Try to change the value of the "Value" property in the "Property Handle Test (Script)" component.

Expected result: The value of the "Value" property can be changed.

Actual result: The value of the "Value" property cannot be changed.
