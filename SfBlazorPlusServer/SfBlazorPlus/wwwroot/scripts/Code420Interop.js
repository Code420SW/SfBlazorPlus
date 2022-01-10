var Code420 = Code420 || {};

Code420.setDocumentTitle = function (title) {
    document.title = title;
};

Code420.setFocus = function (element) {
    element.focus();
};

Code420.setMaskedTextboxPlaceholder = function (labelId, labelText) {
    document.getElementById(labelId).innerText = labelText;
}