function registerInputKeyUpEvent(dotNetObject) {
    let inputElement = document.querySelector('input');
    inputElement.addEventListener('keyup', function (event) {
        dotNetObject.invokeMethodAsync('OnInputKeyUp');
    });
}
