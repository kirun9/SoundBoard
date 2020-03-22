var httpRequest;
var timeStep = 1000;
var path;
var shouldUpdate = false;
var buttons = new Array();

function createButton(song, title, isBack) {
    if (isBack === void 0) { isBack = false; }
    var span = document.createElement("span");
    var a = document.createElement("a");
    a.className = "button";
    a.href = "#";
    var div = document.createElement("div");
    var p = document.createElement("p");
    p.innerHTML = isBack ? "&#128281;" : title;
    div.append(p);
    a.append(div);
    a.setAttribute("data", song);
    a.toggleAttribute("back", isBack);
    a.onclick = function () {
        sendButtonRequest(song);
    };
    span.append(a);
    span.className = "grid-item";
    buttons.push(span);
    document.getElementById("grid").append(span);
}

function start() {
    var favorite = document.getElementById("favoriteNavBar");
    favorite.onclick = function () {
        sendButtonRequest("!favorite!");
    }

    var home = document.getElementById("homeNavBar");
    home.onclick = function () {
        sendButtonRequest("");
    }

    if (timeStep) {
        statusLoop();
    }
}

function statusLoop() {
    if (!httpRequest || httpRequest.readyState === 0) {
        httpRequest = getRequest();
        try {
            httpRequest.open("GET", "status.html", true);
            httpRequest.onreadystatechange = readStatus;
            httpRequest.onerror = function () { httpRequest = null; };
            httpRequest.send(null);
        }
        catch (e) { }
    }
    setTimeout(statusLoop, timeStep);
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

function readStatus() {
    if (httpRequest && httpRequest.readyState === 4 && httpRequest.responseText) {
        if (httpRequest.responseText.charAt(0) !== "<") {
            var json = JSON.parse(httpRequest.responseText);
            if (json.path !== path) {
                path = json.path;
                changeButtons(json);
            }
            else {
                updateButtons(json);
            }
            if (shouldUpdate) {
                changeButtons(json);
                shouldUpdate = false;
            }
        }
        httpRequest = null;
    }
}
function changeButtons(json) {
    var grid = document.getElementById("grid");
    while (grid.lastElementChild) {
        grid.removeChild(grid.lastElementChild);
    }
    buttons = new Array();
    for (var key in json.buttons) {
        if (json.buttons.hasOwnProperty(key)) {
            createButton(json.buttons[key].id, json.buttons[key].title, json.buttons[key].isBack === "true");
        }
    }
}
function updateButtons(json) {
    buttons.forEach(function (span, index, array) {
        for (var key in json.buttons) {
            if (json.buttons.hasOwnProperty(key)) {
                var aElement = span.firstChild;
                if (json.buttons[key].id == aElement.getAttribute("data")) {
                    var playing = json.buttons[key].isPlaying === "true";
                    aElement.toggleAttribute("playing", playing);
                    var favorite = json.buttons[key].isFavorite === "true";
                    aElement.toggleAttribute("favorite", favorite);
                    var dir = json.buttons[key].isDir === "true";
                    aElement.toggleAttribute("dir", dir);
                }
            }
        }
    });
}
function sendButtonRequest(song) {
    var request = getRequest();
    try {
        request.open("POST", "change.html", true);
        request.send(song);
        shouldUpdate = true;
    }
    catch (e) { }
}
