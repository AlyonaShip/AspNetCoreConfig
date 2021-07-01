"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.JwtInterceptor = void 0;
var JwtInterceptor = /** @class */ (function () {
    function JwtInterceptor() {
    }
    JwtInterceptor.prototype.intercept = function (request, next) {
        var token = localStorage.getItem('jwt');
        request = request.clone({
            setHeaders: {
                Authorization: "Bearer " + token
            }
        });
        return next.handle(request);
    };
    return JwtInterceptor;
}());
exports.JwtInterceptor = JwtInterceptor;
//# sourceMappingURL=jwt-interceptor.js.map