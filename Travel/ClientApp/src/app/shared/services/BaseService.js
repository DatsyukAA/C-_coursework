"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Rx_1 = require("rxjs/Rx");
var BaseService = /** @class */ (function () {
    function BaseService() {
    }
    BaseService.prototype.handleError = function (error) {
        var appError = error.headers.get('Application-Error');
        if (appError) {
            return Rx_1.Observable.throw(appError);
        }
        var modelStateErrors = "";
        var serverError = error.json();
        if (!serverError.type) {
            for (var key in serverError) {
                if (serverError[key]) {
                    modelStateErrors += serverError[key] + '\n';
                }
            }
            modelStateErrors = modelStateErrors = '' ? null : modelStateErrors;
            return Rx_1.Observable.throw(modelStateErrors || 'Server error');
        }
    };
    return BaseService;
}());
exports.BaseService = BaseService;
//# sourceMappingURL=BaseService.js.map