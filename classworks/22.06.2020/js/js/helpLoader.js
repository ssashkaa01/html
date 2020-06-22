function loadHtml(file) {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', file, false);
    xhr.onreadystatechange = function () {
        if (this.readyState !== 4) return;
        if (this.status !== 200) return; // or whatever error handling you want
        //console.log(this.responseText);
        //document.getElementById('y').innerHTML = this.responseText;
        document.write(this.responseText);
    };
    xhr.send();
}