function DnnInterop() {
    var urlParams = new URLSearchParams(window.location.search);

    var model = {
        isHost: urlParams.get('isHost'),
        isAdmin: urlParams.get('isAdmin'),
        userId: urlParams.get('userId'),
        portalId: urlParams.get('portalId'),
        requestVerificationToken: urlParams.get('requestVerificationToken')
    };

    return JSON.stringify(model);
}
