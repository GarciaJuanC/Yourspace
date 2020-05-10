//function readURL(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();
//
//        reader.onload = function (e) {
//            $('#upImg')
//                .attr('src', e.target.result);
//        };
//
//        reader.readAsDataURL(input.files[0]);
//    }
//}

$('#blah').click(function () {
    $('#imgInp').click();
})


function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#blah').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$("#imgInp").change(function () {
    readURL(this);
});

//positions each box based on window width and the Y pos of box above it
function layoutBoxes(boxes) {
    var box, boxWidth = 250, boxSpacing = 55, currentPosX = 0, currentPosY = 0, rowItems = 0,
        viewportWidth = document.body.clientWidth;

    for (var i = 0, len = boxes.length; i < len; i++) {
        box = boxes[i];
        box.style.top = 0;

        //if necessary, start new row
        if (currentPosX + 250 > viewportWidth) {
            rowItems = (rowItems == 0) ? i : rowItems;
            currentPosX = 0;
        }

        //calculate top position of current box
        if (rowItems > 0) {
            var boxAbove = boxes[i - rowItems];
            boxAboveHeight = boxAbove.offsetHeight - 30;
            boxAboveY = boxAbove.style.top;

            boxAboveY = (boxAboveY != "" && boxAboveY != 0) ? +boxAboveY.substr(0, boxAboveY.length - 2) - 15 : 0;
            currentPosY = boxAboveHeight + boxSpacing + boxAboveY;
        }

        //set attributes and increment X position
        box.style.cssText = "position: absolute; left: " + currentPosX + "px; top: " + currentPosY + "px; transition: top .8s, left .8s; -webkit-transition: top .8s, left .8s;";
        currentPosX = currentPosX + boxWidth;
    }
}

//init
var boxes = document.getElementsByTagName("div");
layoutBoxes(boxes);

//only reflow and repaint boxes if number of columns has changed
var currentNumCols = Math.floor(document.body.clientWidth % 250);
window.onresize = function () {
    var newNumCols = Math.floor(document.body.clientWidth / 250);
    if (newNumCols != currentNumCols) {
        layoutBoxes(boxes);
        currentNumCols = newNumCols;
    }
}