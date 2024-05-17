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

// Potential improvement to the drawRightAngledLine function
function drawRightAngledLineOld(svgContainerId, startElementId, endElementId) {
    if (startElementId && endElementId && svgContainerId) {
        const svgContainer = document.getElementById(svgContainerId);
        const startElement = document.getElementById(startElementId);
        const endElement = document.getElementById(endElementId);
        const svgRect = svgContainer.getBoundingClientRect();
        const startRect = startElement.getBoundingClientRect();
        const endRect = endElement.getBoundingClientRect();

        const startX = startRect.left - svgRect.left + (startRect.width / 2);
        const startY = startRect.top - svgRect.top + (startRect.height / 2);
        const endX = endRect.left - svgRect.left + (endRect.width / 2);
        const endY = endRect.top - svgRect.top + (endRect.height / 2);

        // Determine the direction of the line based on position
        const dPath = (startY < endY) ?
            `M ${startX} ${startY} V ${(startY + endY) / 2} H ${endX} V ${endY}` :
            `M ${startX} ${startY} H ${(startX + endX) / 2} V ${endY} H ${endX}`;

        const newPath = document.createElementNS("http://www.w3.org/2000/svg", "path");
        newPath.setAttribute("d", dPath);
        newPath.setAttribute("stroke", "blue");
        newPath.setAttribute("stroke-width", "2");
        newPath.setAttribute("fill", "none");

        svgContainer.querySelector('svg').appendChild(newPath);
    }
}

function drawRightAngledLine(svgContainerId, startElementId, endElementId) {
    if (startElementId && endElementId && svgContainerId) {
        const svgContainer = document.getElementById(svgContainerId);
        const startElement = document.getElementById(startElementId);
        const endElement = document.getElementById(endElementId);
        const svgRect = svgContainer.getBoundingClientRect();
        const startRect = startElement.getBoundingClientRect();
        const endRect = endElement.getBoundingClientRect();

        const startX = startRect.left - svgRect.left + (startRect.width / 2);
        const startY = startRect.top - svgRect.top + (startRect.height / 2);
        const endX = endRect.left - svgRect.left + (endRect.width / 2);
        const endY = endRect.top - svgRect.top + (endRect.height / 2);

        // Modified path to continue vertically until the same height as the destination
        const dPath = `M ${startX} ${startY} V ${endY} H ${endX}`;

        const newPath = document.createElementNS("http://www.w3.org/2000/svg", "path");
        newPath.setAttribute("d", dPath);
        newPath.setAttribute("stroke", "#084F95");
        newPath.setAttribute("stroke-width", "2");
        newPath.setAttribute("fill", "none");

        svgContainer.querySelector('svg').appendChild(newPath);
    }
}