var fs = require('fs');
var postcss = require('postcss');
var styleguide = require('postcss-style-guide');
var input = fs.readFileSync('styleguide/styleguide.css', 'utf8');
 
input = input
    .replace('../images/', 'images/')
    .replace('../fonts/', 'fonts/');
    
var output = postcss([
    styleguide
]).process(input)
.then(function(result) {
    console.log('Styleguide generated!!');
});