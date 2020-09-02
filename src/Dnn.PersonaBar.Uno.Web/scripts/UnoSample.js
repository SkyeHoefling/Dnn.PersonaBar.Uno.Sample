'use strict';
define(
    function () {

        return {
            init: function (wrapper, util, params, callback) {
                var personaBarSettings = window.parent['personaBarSettings'];
                var token = window.parent.document.getElementsByName('__RequestVerificationToken')[0];
                var host = window.location.protocol.concat('//').concat(window.location.hostname);

                var unoFrame = document.getElementById('uno-frame');
                if (unoFrame !== null) {
                    var src = unoFrame.src +
                        '?isHost=' + personaBarSettings.isHost +
                        '&isAdmin=' + personaBarSettings.isAdmin +
                        '&userId=' + personaBarSettings.userId +
                        '&portalId=' + personaBarSettings.portalId +
                        '&requestVerificationToken=' + token.value;

                    unoFrame.src = src;
                }
            },

            initMobile: function (wrapper, util, params, callback) {
            },

            load: function (params, callback) {
                var requestVerificationToken = document.getElementsByName('__RequestVerificationToken')[0];

            },

            loadMobile: function (params, callback) {
            }
        };
    });
