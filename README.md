# SfBlazorPlus
The goal of this project is to simplify use of the SyncFusion Blazor library for those not well versed in CSS.
Short- and Long-Terms Goals and an intermediate Roadmap to follow.

## Background
Writing web-bassed applications is great with Blazor and made better when incorporating component libraries. This
project uses the SyncFusion Blazor library. Why SyncFusion? Good capabilities, great support and a generous community
license policy. 

One of the down sides of using a component library is that you remain entangled with having to learn HTLM and CSS to
a greater degree than other Blazor packages that are more framework-based (they hide these complexities to the maximum)
extent possible). Authors wanting to tailor application styling are tasked with a certain degree of HTML and CSS mastery.
Generalized component libraries don't always lend themselves towards extensibility and testability. I'll leave that thought
alone until later.

Composing HTML in Razor pages is the norm and will become messy as page content grow. Add in custom CSS syling and the mess grow.
Razor components are a great way to reduce the clutter through encapsulation. Building single-responsibility composite
components are the way to go, in my opinion.

## Long-Term Project Goals
1. Build a series of base components that encapsulate the SyscFusion libaray
2. Incorporate methods in the base components to extend programmatic control and testability
3. Build generalized composite components encapsulating one or mode base and composite compoments
4. Build single-responsibility composite components
5. All base components will expose the most common CSS styling elemnets through parameters
6. To the maximum extent possible, provide default setting for the CSS parameters so the user has a starting point