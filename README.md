# SfBlazorPlus
The goal of this project is to simplify use of the SyncFusion Blazor library for those not well versed in CSS.
Short- and Long-Terms Goals and an intermediate Roadmap to follow.

## Background
Writing web-bassed applications is great with Blazor and made better when incorporating component libraries. This
project uses the SyncFusion Blazor library. Why [SyncFusion](https://www.syncfusion.com/blazor-components)? Good capabilities, great support and a [generous community
license policy](https://www.syncfusion.com/products/communitylicense). 

One of the down sides of using a component library is that you remain entangled with having to learn HTLM and CSS to
a greater degree than other Blazor packages that are more framework-based (they hide these complexities to the maximum
extent possible). Authors wanting to tailor application styling are tasked with a certain degree of HTML and CSS mastery.
Generalized component libraries don't always lend themselves towards extensibility and testability. I'll leave that thought
alone until later.

Composing HTML in Razor pages is the norm and will become messy as page content grow. Add in custom CSS syling and the mess grows.
Add in custom CSS styling--getting messier. Try to apply different styling to components that share CSS classes and the task becomes 
almost unmanageable. Razor components are a great way to reduce the clutter through encapsulation. Building single-responsibility composite
components are the way to go, in my opinion.

## Long-Term Project Goals
1. Build a series of base components that encapsulate SyncFusion libaray components
2. Develop a method to isolate CSS styling to a targeted component
3. Incorporate methods in the base components to extend programmatic control and testability
4. Build generalized composite components encapsulating one or more base and composite compoments
5. Build single-responsibility composite components
6. All base components will expose the most common CSS styling elemnets through parameters
7. To the maximum extent possible, provide default setting for the CSS parameters so the user has a starting point to which customizations can be applied and provides links to additional information for each CSS syling parameter

## Short-Term Project Goals
Don't try to boil the ocean. Use a staged, task-based approach to acheiving the long-term goals.

#### [Stage 1](https://github.com/Code420SW/SfBlazorPlus/wiki/Stage-1): Complete
#### [Stage 2](https://github.com/Code420SW/SfBlazorPlus/wiki/Stage-2): Complete
#### [Stage 3](https://github.com/Code420SW/SfBlazorPlus/wiki/Stage-3): Pending


## Project Issues
The following chronicles issues opened for the project and their status.

#### [Rationalize styling of the ButtonBase component](https://github.com/Code420SW/SfBlazorPlus/issues/2): Open
