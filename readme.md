# SXA.Foundation.Variants

A collection of custom SXA rendering variants and some other useful things ie. custom NVelocity tools that may be helpful in your solution.

## Making it work

You don't need to have entire library as it comes from repository, please feel free to pick up only those parts that you need with relevant dependencies. For your convenience variants' code is grouped into folders.

Also do not forget to change items IDs to those you make on your instance.

### Prerequisites

After cloning the repository, please add NuGet references to following Sitecore and SXA libraries (alternatively simply drop them into /libs folder):

```
Sitecore.Kernel
Sitecore.NVelocity
Sitecore.XA.Foundation.Mvc
Sitecore.XA.Foundation.Abstractions
Sitecore.XA.Foundation.RenderingVariants
Sitecore.XA.Foundation.SitecoreExtensions
Sitecore.XA.Foundation.Variants.Abstractions
```

## Blog posts

* [Script Variant field](http://blog.martinmiles.net/post/script-rendering-variant-field-in-sxa-why-would-one-need-it) - executes custom JS script in order to interact with other elements. see use cases
* [Image Section Variant field](http://blog.martinmiles.net/post/creating-a-custom-rendering-variant-section-to-render-element-with-background-image) - works like a section but features a backgroung image from Sitecore passed through style
* [Item Reference Variant field](http://blog.martinmiles.net/post/welcome-item-reference-a-rendering-variant-field-missing-out-of-the-box-in-SXA) - use this field to reference another item, especially when referencing data items to rendering variants
* [Query Parameter Variant field](http://blog.martinmiles.net/post/sxa-implementing-url-query-parameter-rendering-variant-with-little-efforts) - use it to extract and display a value of param from URL qury string 
* [NVelocity Extensions](http://blog.martinmiles.net/post/creating-custom-sxa-components-with-rendering-variants-and-almost-no-codebehind-on-an-example-of-social-share-buttons) - this walkthrough has an explanation of how NVelocity templates work


### Other notes

At this stage neither package with items, nor serialization are not provided, so you might need to create those yourself (as per blog post guidances) and change the ID references in code.
At the moment project has .NET Framework 2.6.2 runtime, so running it with Sitecore 9.1+ will require changing runtime from you.

## Contact author

* [Twitter](https://twitter.com/SitecoreMartin) - Twitter
* [LinkedIn](https://www.linkedin.com/in/martin-miles/) - LinkedIn profile
* [Sitecore Slack](https://sitecorechat.slack.com/team/U0KDE1VD3/) - reference to a profiles at Sitecore Slack channel
* [Blog](http://blog.MartinMiles.net/) - "Experience Sitecore!" blog with plenty of interesting things about Sitecore and its implementation