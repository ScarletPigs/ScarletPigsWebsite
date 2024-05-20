function elementExists(elementId) {
    return document.getElementById(elementId) !== null;
}

function drawRightAngledLine(svgContainerId, startElementId, endElementId, color, thickness) {
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
        newPath.setAttribute("stroke", color);
        newPath.setAttribute("stroke-width", thickness);
        newPath.setAttribute("fill", "none");

        svgContainer.querySelector('svg').appendChild(newPath);
    }
}