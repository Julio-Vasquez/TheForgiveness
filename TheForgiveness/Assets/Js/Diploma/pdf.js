
function downloadCanvas(canvasId) {
    window.scrollTo(0, 0);
    html2canvas(document.querySelector(canvasId)).then(function (canvas) {
        saveAs(canvas.toDataURL("image/png"));
    });
    window.scrollTo(0, document.body.scrollHeight || document.documentElement.scrollHeight);
}


function saveAs(uri) {
    var link = document.createElement('a');
    if (typeof link.download === 'string') {
        link.href = uri;
        link.download = 'Diploma';
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    } else {
        window.open(uri);
    }
}