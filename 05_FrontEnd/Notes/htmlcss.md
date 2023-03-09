# HTML & CSS

## HTML
- Hypertext Markup language
- This markup language determines the structure of web pages
- We use tags to denote different sections of the website
```html
<html>
    <head></head>
    <body>
        <h1>Hello World!</h1>
        <img src="" />
    </body>
</html>
```
- not a programming language
    - can't process logic
    - no loops, conditionals, variables
- current standard HTML 5
- Element
    - This is a fundamental building block of a webpage
    - <html></html> : a tag with opening and closing tag
    - <p>Text Goes Here</p>
    - <img/>, <hr/> : a self closing tag
- Attributes
    - These are additional information you can provide to a tag to customize its behavior
    - very akin to flags in command line commands
    - Global attributes:
        - Attributes which you can use for any elements
        - id, class, style, etc.
    - href : can only use with certain elem such as <a href="#">Link</a>
- id vs class:
    - id: is meant to uniquely identify an element (only one unique id in a web page)
        - 1-1 relationship 
    - class: is an attribute meant to group elements together
        - You can assign multiple classes to an element
        - a class can have multiple elements associated with it
        - M-M relationship
- Accessibility
    - alt attribute in img tags
    - only attach click event handler to buttons (for screen readers) 
    - semantic html
    - color schemes (For color blindness)
    - Title attribute

## CSS
- Cascading Style Sheet
- Cascading means falling down in a waterfall
    - This means the styles will be applied in a cascading fashion, in a way that the styles that appear later in a file will overwrite the styles that appeared earlier in the file
- Selectors
    - A way to target styles to a certain elements
    - Tag
    - Id
    - Class
    - Pseudo Class
    - Pseudo Element
    - Sibling/Descendent/etc.
    - Combination Selector

- Box Model
    - height/width
    - content : actually holds the child elements and any other content of the element
    - padding : is the space between border and content (if you apply background color, padding will also be affected by it) 
    - border : is the border (visible, graphical border) of the element
    - margin : is the space outside of the border (the background color doesn't get applied to margin)

- different display options
    - block (take up the whole width its given ie div, p, headings, etc)
    - inline (does not take up any more space than it needs, ie span)
    - flex (super fun, check it out)

- Responsive Web Design
    - A design technique that makes sure your websites look good in different screen sizes
        - Whether your users are using iphone SE, galaxy S12, iphone 14, your 32" curved monitor, you want your website to look pretty and work well w/o the massive horizontal scrolls and tiny fonts

- Mobile First Design technique
    - Designs the mobile layout First, and then expand outward to cater to desktop users
    - because, mobile usage is becoming more and more prevalent

- Bootstrap
    - Powerful HTML/CSS/JS library
