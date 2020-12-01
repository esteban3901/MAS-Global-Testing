"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.HomeComponent = void 0;
var core_1 = require("@angular/core");
var HomeComponent = /** @class */ (function () {
    function HomeComponent(employeeService) {
        this.employeeService = employeeService;
        this.employees = [];
    }
    //#region Functions
    HomeComponent.prototype.search = function () {
        var _this = this;
        this.employeeService.GetAll().subscribe(function (resp) {
            _this.employees = resp.result;
        });
    };
    HomeComponent.prototype.searchEmployee = function (value) {
        var _this = this;
        if (value > 0) {
            this.employeeService.GetById(value).subscribe(function (resp) {
                _this.employees = [];
                if (resp.result)
                    _this.employees.push(resp.result);
            });
        }
        else {
            this.search();
        }
    };
    HomeComponent = __decorate([
        core_1.Component({
            selector: 'app-home',
            templateUrl: './home.component.html',
        })
    ], HomeComponent);
    return HomeComponent;
}());
exports.HomeComponent = HomeComponent;
//#endregion
//# sourceMappingURL=home.component.js.map