function DnnGetSettings() {
    var rootDnnWindow = window.parent.parent;
    if (rootDnnWindow === undefined || rootDnnWindow === null) {
        console.log('Unable to retrieve Persona Bar Settings!');
        return {};
    }

    var personaBarSettings = rootDnnWindow['personaBarSettings'];
    var tokenInput = rootDnnWindow.document.getElementsByName('__RequestVerificationToken')[0];

    var model = {
        isHost: personaBarSettings.isHost,
        isAdmin: personaBarSettings.isAdmin,
        userId: personaBarSettings.userId,
        portalId: personaBarSettings.portalId,
        requestVerificationToken: tokenInput.value
    };

    return JSON.stringify(model);
}

function DnnGetHost() {
    return window.location.origin;
}
