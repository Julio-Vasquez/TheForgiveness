// Basic Example with form
var form = $("#example-form");
form.validate({
    errorPlacement: function errorPlacement(error, element) { element.before(error); }
});
form.children("div").steps({
    headerTag: "h3",
    bodyTag: "section",
    transitionEffect: "slideLeft",
    
});