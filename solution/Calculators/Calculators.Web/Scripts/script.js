function navClick(elem) {
    elem.parentElement.classList.toggle('active');
    //var bodyId = elem.dataset.bodyId;
    //var body = document.getElementById(bodyId.toString());
    //$(body).slideToggle();
}

var preloaderClassList = function() {
    return document.getElementById('result-loader').classList;
}

var resultElementClassList = function() {
    return document.getElementById('result').classList;
}

function resultLoading() {
    preloaderClassList().add('load');
    resultElementClassList().remove('load');
}

function resultLoaded() {
    setTimeout(function() {
        preloaderClassList().remove('load');
        resultElementClassList().add('load');
    }, 1000);
}