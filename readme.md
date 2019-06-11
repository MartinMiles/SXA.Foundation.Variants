# SXA.Foundation.Variants

A collection of custom SXA rendering variants and some other useful things ie. custom NVelocity tools that may be helpful in your solution.

![SXA.Foundation.Variants](https://raw.githubusercontent.com/wiki/MartinMiles/SXA.Foundation.Variants/images/main.png "SXA.Foundation.Variants") 

## Making it work

You don't need to have entire library as it comes from repository, please feel free to pick up only those parts that you need with relevant dependencies. For your convenience variants' code is grouped into folders.

Also do not forget to change items IDs to those you make on your instance.

### Prerequisites

After cloning the repository, please add NuGet references to following Sitecore and SXA libraries (alternatively simply drop them into `/libs` folder):

```
Sitecore.Kernel
Sitecore.NVelocity
Sitecore.XA.Foundation.Mvc
Sitecore.XA.Foundation.Abstractions
Sitecore.XA.Foundation.RenderingVariants
Sitecore.XA.Foundation.SitecoreExtensions
Sitecore.XA.Foundation.Variants.Abstractions
```

## Variants

Below you may find the list of variants provided with this module along with its brief description and output.

#### 1. Image section

Renders selected tag (`<div>`, `<span>`, etc.) with an image from Sitecore Media Library passed at background image style attribute. There's no need to create a **Container** component with all nesting HTML structure anymore just in order to pass a background image with a style to it. 
Here is a sample of output:
```
<div style="background-image: url(/-/media/Project/Tenant/This-image-comes-from-Media-Library.jpg)">
// any children rendered here
</div>
```




#### 2. Image with class

When using built-in **Responsive Image** variant field, `<img>` tag always got wrapped by some other element, that one can assign a class, but there is no way to render simply image tag with a class name specified. Give variant field fixes that by allowing to output something similar to:

```
<img src="/-/media/Some-image-comes-from-Media-Library.jpg" class="specified-from-variant-field" />
```
**Note:** this component is redundant since you can achieve that same result by using an **Image field** below (when using it without specifying link).






#### 3. Image link

This is quite powerful and at the same time very simple rendering variant field - it nicely renders `<img>` tag surrounded with `<a>` anchor tag without any of other unwanted wrappings normally coming when nesting components in SXA.

An image from media library can be statically referenced or taken out of a context item field of **Image** type. Please note, that static reference always takes over a context field, if both set.

Another feature that is not easy achievable out of the box is ability to specify individual CSS classes for both `<a>` and `<img>` tags. If link is not set - it will simply render an image with class, achieving the same as previous **Image with class** variant field does.

```
<a href="http://link.to/internal-or-external-item" class="individual-class-for-anchor">
    <img src="/-/Media-item-from-sitecore" class="individual-class-for-image"/>
</a>
```






#### 4. Query string

This field renders a value of a URL query string parameter passed with a GET-alike request, of course the value comes URL decoded.

```
<span>
// simply outputs the value from query strng wrapped with a selected tag
</span>
```


#### 5. Inline script

This variant field allows placing a JavaScript code to interact with existing page structure and execute this script upon page load. It may also interact with any JS framework that your site is using. 
Please refer to the corresponding blog bost (links are located below), as it describes few useful cases when and how it may be helpful.

The field outputs just a `<script>` tag with the code provided:

```
<script defer>
    console.log("Place here you JavaScript code to be executed once page load completes");
</script>
```


#### 6. Script reference tag

This one allows you referenceing a JavaScript files stored at your media library. The output looks as below:

```
<script type="text/javascript" defer="" src="/-/media/Library/Path/To/your-file.js"></script>
```


#### 7. Item reference

Works similar to built-in **Reference** variant field, but instead of switching a context to an item referenced from a field of context item, it allows statically selecting any item from a Sitecore tree and switch context to that one. 
Obviously, that would apply to every single instance of rendering variant, but it may be helpful when you are referencing some statical labels that at the same time are content editable and thus should be kept in data area of a site, not in definition items which rendering variants belong to.

```
// field does not provide any output, but simply changes the context.
```


## NVelocity extensions

Unlike the above, these custom tools work with built-in NVelocity templates (**Template** variant field), and allow to extend its functionality beyond two tools built in by default (**DateTool** and **NumberTool**).
Currently there are two more tools coming with this module:

#### 1. Item Field Tool

Contains two methods:

* `GetItemReferenceItem` - works similar to Item Reference rendering variant field, but withing NVelocity template. It returns another (referenced) item, referenced at some field of context item.
* `GetFixedReferenceItem` - an alternative to the one above, where instead of getting a reference from a context page you can statically specify it by providing guid or path to switch context to.
* `GetField` - simply returns the field value of context item.

Call usages:

```
$itemFieldTool.GetItemReferenceItem($item, "Field with reference ie. droplink")
$itemFieldTool.GetField($item, "Field name to read from")
```




#### 2. Link Tool

Contains two methods:

* `GetCurrent` - returns full URL of a current context item (ie. current page URL)
* `GetItemLink` - return full URL of a provided item. Boolean parameter difines whether to generate full or relative URL
* `RenderLink` - uses FieldRenderer in order to render items of Link type (having Link field) passing an optional specific CSS class

Call usages:

```
$linkTool.GetCurrent()
$linkTool.GetItemLink($item,true)
$linkTool.RenderLink($item,"some-custom-CSS-class")
```

## Related blog posts

* [Script Variant field](http://blog.martinmiles.net/post/script-rendering-variant-field-in-sxa-why-would-one-need-it) - executes custom JS script in order to interact with other elements. see use cases
* [Image Section Variant field](http://blog.martinmiles.net/post/creating-a-custom-rendering-variant-section-to-render-element-with-background-image) - works like a section but features a backgroung image from Sitecore passed through style
* [Item Reference Variant field](http://blog.martinmiles.net/post/welcome-item-reference-a-rendering-variant-field-missing-out-of-the-box-in-SXA) - use it to reference another item, especially referencing data items from rendering variants
* [Query Parameter Variant field](http://blog.martinmiles.net/post/sxa-implementing-url-query-parameter-rendering-variant-with-little-efforts) - use it to extract and display a value of param from URL qury string 
* [NVelocity Extensions](http://blog.martinmiles.net/post/creating-custom-sxa-components-with-rendering-variants-and-almost-no-codebehind-on-an-example-of-social-share-buttons) - this walkthrough has an explanation of how NVelocity templates work
* [Image Link with classes](http://blog.martinmiles.net/post/image-tag-wrapped-with-anchor-both-having-own-classes-but-without-any-unwanted-component-wrappings-easy-not-oob-in-sxa-but-here-is-the-fix) - adds `<img>` tag wrapped with `<a>` tag, both having own classed with no extra wrappings 


### Other notes

At this stage neither package with items, nor serialization are not provided, you might need to create those yourself (as per blog post guidances) and change the ID references in code.
At the moment project has **.NET Framework 4.6.2** runtime, so running it with Sitecore 9.1+ requires changing runtime before rebuild.

There is a package provided at `Sitecore packages` folder that installs all rendering variant field templates on your system under `/sitecore/templates/Foundation/Tenant/Rendering Variants` folder (renane `Tenant` to your actual value). 
However, it deploys neither binaries, not configuration - due to that target environments may vary, you might also rename namespaces and adjust changes in the configuration. 
Once compiled, simply copy dll and config into corresponding folders.

## Contact author

* [Twitter](https://twitter.com/SitecoreMartin) - Twitter
* [LinkedIn](https://www.linkedin.com/in/martin-miles/) - LinkedIn profile
* [Sitecore Slack](https://sitecorechat.slack.com/team/U0KDE1VD3/) - reference to a profiles at Sitecore Slack channel
* [Author's blog](http://blog.MartinMiles.net/) - "Experience Sitecore!" blog with plenty of interesting things about Sitecore and its implementation