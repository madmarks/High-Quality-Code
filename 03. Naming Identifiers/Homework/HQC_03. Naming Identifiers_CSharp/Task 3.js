function buttonCheckForMozillaBrowser(event, args) {

    'use strict';

    var browserWindow = window,
        browserName = browserWindow.navigator.appCodeName,
        isMozilla = browserName === "Mozilla";

    if (isMozilla) {

        alert("Yes");

    } else {

        alert("No");

    }
}