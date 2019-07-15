

function addQueryString(url, key, value) {
    if (value != null && value != '') {
        if (url.indexOf("?") <= 0) {
            url = url + "?" + key + "=" + value;
        }
        else {
            url = url + "&" + key + "=" + value;
        }
    }
    return url;
}

function getQueryStringValue(url, key) {
    return getParameterByName(url, key);
    //return unescape(url.replace(new RegExp("^(?:.*[&\\?]" + escape(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}

function getParameterByName(url, name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(url);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function getLink(){
	return window.location.href.substring(0,window.location.href.lastIndexOf("/")+1);
}

var patt = new RegExp("(?:javascript:{OpenWindowsWHRNS\\(')(.*)'","gi");
var res = patt.exec($("a[href*=OpenWindowsWHRNS").prop("href"));
url = addQueryString(res[1], 'k', getQueryStringValue(window.location.href, 'k'));

chrome.runtime.sendMessage({ Tipo: "abrir_midia", link: getLink() + url });

