function getElementPosition(elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        var rect = element.getBoundingClientRect();
        return { x: rect.left + window.scrollX, y: rect.top + window.scrollY };
    }
    return null;
}

function getElementDetails(elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        var rect = element.getBoundingClientRect();
        return {
            Left: rect.left,
            Top: rect.top,
            Right: rect.right,
            Bottom: rect.bottom,
            Width: rect.width,
            Height: rect.height
        };
    }
    return null;
}