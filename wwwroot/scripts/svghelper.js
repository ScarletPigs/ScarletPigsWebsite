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

function drawRightAngledLine(svgContainer, startElement, endElement) {
    if (startElement && endElement && svgContainer) {
        const svgRect = svgContainer.getBoundingClientRect(); // Get bounding rectangle of the svg container
        const startRect = startElement.getBoundingClientRect();
        const endRect = endElement.getBoundingClientRect();

        // Adjust the coordinates by subtracting the top left coordinates of the SVG container
        const startX = startRect.left - svgRect.left + (startRect.width / 2); // Adjust to center of the element
        const startY = startRect.top - svgRect.top + (startRect.height / 2); // Adjust to center of the element
        const endX = endRect.left - svgRect.left + (endRect.width / 2); // Adjust to center of the element
        const endY = endRect.top - svgRect.top + (endRect.height / 2); // Adjust to center of the element

        // Define the path using the adjusted coordinates
        const dPath = `M ${startX} ${startY} H ${(startX + endX) / 2} V ${endY} H ${endX}`;
        const newPath = document.createElementNS("http://www.w3.org/2000/svg", "path");
        newPath.setAttribute("d", dPath);
        newPath.setAttribute("stroke", "black");
        newPath.setAttribute("stroke-width", "2");
        newPath.setAttribute("fill", "none");

        svgContainer.querySelector('svg').appendChild(newPath);
    }
}

// Potential improvement to the drawRightAngledLine function
function drawRightAngledLineImproved(svgContainer, startElement, endElement) {
    console.error('drawRightAngledLine');
    if (startElement && endElement && svgContainer) {
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
        newPath.setAttribute("stroke", "black");
        newPath.setAttribute("stroke-width", "2");
        newPath.setAttribute("fill", "none");

        svgContainer.querySelector('svg').appendChild(newPath);
    }
}