var oldjson;
var displaying = new Object();
var timeStep = 1000;
var lastElement;

function start() {
    if (timeStep) {
        statusLoop();
    }
}

function statusLoop() {
    var httpRequest = getRequest();
    try {
        httpRequest.open("GET", "playing.html", true);
        httpRequest.onreadystatechange = function () {
            if (httpRequest && httpRequest.readyState === 4 && httpRequest.responseText) {
                if (httpRequest.responseText.charAt(0) !== "<") {
                    var json = JSON.parse(httpRequest.responseText);
                    showText(json, oldjson);
                    oldjson = json;
                }
            }
        }
        httpRequest.onerror = function () { httpRequest = null; };
        httpRequest.send(null);
    }
    catch (e) { }
    setTimeout(statusLoop, timeStep);
}

function showText(json, oldjson) {
    for (var key in json.players) {
        if (json.players.hasOwnProperty(key)) {
            if (!displaying.hasOwnProperty(key)) {
                displaying[key] = new Object();
                displaying[key].id = json.players[key].id;
                displaying[key].title = json.players[key].title;
                displaying[key].displayingStatus = 0;
            }
        }
    }
    if (oldjson) {
        for (var key in displaying) {
            if (displaying.hasOwnProperty(key)) {
                if (!oldjson.players.hasOwnProperty(key)) {
                    if (displaying[key].displayingStatus === 2) {
                        delete displaying[key];
                    }
                }
                if (displaying[key] && displaying[key].displayingStatus === 0) {
                    createElement(displaying[key]);
                }
            }
        }
    }
}

function createElement(info) {
    info.displayingStatus = 1;
    var element = document.createElement("li");
    element.innerText = info.title;
    if (lastElement) {
        lastElement.className = lastElement.className.replace("last-child", "").trim();
    }
    lastElement = element;
    element.className = element.className + "last-child";
    document.getElementById("list").appendChild(element);

    setTimeout(function () {
        element.className = element.className + " show";
    }, 10);
    element.addEventListener("webkitAnimationEnd", function() {
        info.displayingStatus = 2;
        document.getElementById("list").removeChild(element);
    });
    element.addEventListener("animationend", function() {
        info.displayingStatus = 2;
        document.getElementById("list").removeChild(element);
    });
}


function getRequest() {
    try {
        return new ActiveXObject("Msxml2.XMLHTTP");
    }
    catch (e) {
        try {
            return new ActiveXObject("Microsoft.XMLHTTP");
        }
        catch (err) { }
    }
    if (typeof XMLHttpRequest !== "undefined") {
        return new XMLHttpRequest();
    }
    return null;
}